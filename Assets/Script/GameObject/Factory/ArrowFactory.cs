using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Arrow�𐶐�����H��
/// </summary>
public class ArrowFactory : Singleton<ArrowFactory>
{
    /// <summary>
    /// ����Prefab��GameObject
    /// </summary>
    [SerializeField]
    private GameObject m_arrowPrefab = null;

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
    }

    /// <summary>
    /// GameObject�̉������
    /// </summary>
    protected override void Release()
    {

    }

    /// <summary>
    /// Arrow��GameObject�𐶐�����
    /// </summary>
    /// <param name="star">Arrow�̐e�I�u�W�F�N�g</param>
    /// <param name="relative">Arrow�ɐe�q�t�������ۂ̑��΍��W</param>
    public void CreateArrow(SpiralStar star,in Vector3 relative) 
    {
        //����GameObject�̃��[���h���W��ݒ肷��
        Vector3 worldPos = new Vector3(star.rigidBody2D.position.x,star.rigidBody2D.position.y,0.0f) + relative;

        //�v���n�u�̃C���X�^���X�𐶐�
        star.arrow = Instantiate(m_arrowPrefab, worldPos, Quaternion.identity);
    }

    /// <summary>
    /// ����GameObject���폜����
    /// </summary>
    /// <param name="star">���̐e�I�u�W�F�N�g</param>
    public void ReleaseArrow(SpiralStar star)
    {
        //����GameObject���폜����
        Destroy(star.arrow);

        //��������������
        star.arrow = null;
    }
}
