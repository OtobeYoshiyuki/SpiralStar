using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFactory : Singleton<EffectFactory>
{
    [SerializeField]
    private ParticleSystem m_starEffect = null;

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
    /// �Փˎ��̃G�t�F�N�g�̐���
    /// </summary>
    /// <param name="star">Star�̃C���X�^���X</param>
    [System.Obsolete]
    public void SpawnStarEffect(StarBase star)
    {
        //SpriteRenderer���擾����
        SpriteRenderer sprite = star.GetComponent<SpriteRenderer>();

        //effect��GameObject�𐶐�
        ParticleSystem starEffect = Instantiate(m_starEffect,star.transform.position,Quaternion.identity);

        //effect�̐F��ύX����
        starEffect.startColor = sprite.color;

        //�G�t�F�N�g���Đ�����
        starEffect.Play();
    }
}
