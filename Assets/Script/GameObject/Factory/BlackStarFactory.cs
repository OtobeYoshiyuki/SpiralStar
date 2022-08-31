using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlackStar�𐶐�����H��
/// </summary>
public class BlackStarFactory : Singleton<BlackStarFactory>
{
    /// <summary>
    /// �G��Base�ƂȂ�v���n�u
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private GameObject m_starPrefab = null;

    /// <summary>
    /// ����������W���w�肷��
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private List<Vector3> m_spawnLocations = null;

    /// <summary>
    /// �摜�̐F���w�肷��
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private List<Color> m_spriteColors = null;

    /// <summary>
    /// �G�̃C���X�^���X
    /// </summary>
    private List<GameObject> m_enemyStars = null;

    /// <summary>
    /// �G�̐�
    /// �萔
    /// </summary>
    public const int MAX_NUM = 1; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �C���X�^���X�̏���������
    /// </summary>
    protected override void Init()
    {
        //GameObject�̃C���X�^���X��ێ����炽�߂�List�𐶐�
        m_enemyStars = new List<GameObject>();
    }

    /// <summary>
    /// GameObject�̉������
    /// </summary>
    protected override void Release()
    {
        //ReleaseBlackStar(0);
    }

    /// <summary>
    /// �GGameObject�𐶐�
    /// </summary>
    /// <param name="star">Player��Star</param>
    /// <param name="num">�������鐔</param>
    public void CreateBlackStar(SpiralStar star,in int kinds)
    {
        //�GGameObject�𐶐�
        GameObject enemyStar = Instantiate(m_starPrefab, m_spawnLocations[kinds], Quaternion.identity);

        //���N���X��Player�N���X�̃C���X�^���X��o�^
        enemyStar.GetComponent<BalanStar>().starPlayer = star;

        //���ʂ���ID��o�^����
        enemyStar.GetComponent<BalanStar>().id = kinds;

        //�摜�̐F��ݒ肷��
        enemyStar.GetComponent<SpriteRenderer>().color = m_spriteColors[kinds];

        //�G��List�ɒǉ�
        m_enemyStars.Add(enemyStar);

    }

    /// <summary>
    /// �GGameObject�����
    /// </summary>
    /// <param name="id">���ʔԍ�</param>
    public void ReleaseBlackStar(in int id)
    {
        for (int i = 0;i < m_enemyStars.Count;i++)
        {
            //�h���N���X�̃X�N���v�g���擾����
            BalanStar balanStar = m_enemyStars[i].GetComponent<BalanStar>();

            //����ID��GameObject������������
            if(balanStar.id == id)
            {
                //�I�u�W�F�N�g����������
                Destroy(m_enemyStars[i]);

                //�z��̗v�f������
                m_enemyStars.RemoveAt(i);

                //��x��������A�ق��̏����͔�΂�
                return;
            }
        }
    }
}
