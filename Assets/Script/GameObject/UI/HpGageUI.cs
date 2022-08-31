using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HpGageUI : Singleton<HpGageUI>
{
    /// <summary>
    /// HP�Q�[�W�̏������̏��
    /// </summary>
    enum HPGAGE_CHILD_INIT : int
    {
        FRONT = 5,//�O�ʂ̃A�j���[�V����
        BACK = 4,//��ʂ̃A�j���[�V����
    }

    /// <summary>
    /// �z��̕␳��̒l
    /// </summary>
    public const int REVERS_ELEMENT = (int)HPGAGE_CHILD_INIT.FRONT;

    /// <summary>
    /// �Q�[�W�̊Ǘ��N���X
    /// </summary>
    private GageManager m_gageManager = new GageManager();

    /// <summary>
    /// �A�j���[�V�����J�[�u
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private AnimationCurve m_damageCurve = null;

    /// <summary>
    /// �A�j���[�V�����J�[�u
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private AnimationCurve m_healCurve = null;

    // Update is called once per frame
    void Update()
    {
        //gageManager�̍X�V����
        m_gageManager.UpdateGageManager();
    }

    /// <summary>
    /// ����������
    /// </summary>
    protected override void Init()
    {
        //���[�v�ŉ񂷒l��z��ɒǉ�����
        List<HPGAGE_CHILD_INIT> _CHILD_INITs = new List<HPGAGE_CHILD_INIT> { HPGAGE_CHILD_INIT.FRONT, HPGAGE_CHILD_INIT.BACK };

        foreach(HPGAGE_CHILD_INIT _CHILD_INIT in _CHILD_INITs)
        {
            //�Q�[�W�̃A�j���[�V�����𐶐�����
            GageAnimation animation = new GageAnimation();

            //�q���ɃA�^�b�`����Ă���ImageComponent��ݒ肷��
            animation.gage = transform.GetChild((int)_CHILD_INIT).gameObject.GetComponent<Image>();

            //GageManager�ɃA�j���[�V������ǉ�����
            m_gageManager.AddGage(animation);
        }

    }

    /// <summary>
    /// �p������
    /// </summary>
    protected override void Release()
    {
    }

    /// <summary>
    /// �Q�[�W�̃_���[�W�A�j���[�V�������s��
    /// </summary>
    /// <param name="self">�������g</param>
    public void OnGageDamageAnimation(StarBase self)
    {
        //�A�j���[�V�����̋N��
        m_gageManager.isAnimation = true;
        m_gageManager.animeTime = 0.0f;

        //�Y�����ɕϊ�����
        int front = Utility.AbsCaclInt((int)HPGAGE_CHILD_INIT.FRONT, REVERS_ELEMENT);
        int back = Utility.AbsCaclInt((int)HPGAGE_CHILD_INIT.BACK, REVERS_ELEMENT);

        //�Q�[�W���擾����
        GageAnimation frontGage = m_gageManager.GetGageAnimation(front);
        GageAnimation backGage = m_gageManager.GetGageAnimation(back);

        //������o�^����
        frontGage.gage.fillAmount = self.statusCs.GetTargetStatus(StarBase.HP) / 
            StatusManager.Instance.dataBase.MaxStatus(StarBase.HP);

        //�A�j���[�V�����N���X���Ŏ��s����֐���o�^����
        backGage.imageAction = () =>
        {
            backGage.gage.fillAmount = frontGage.gage.fillAmount + 
            ((backGage.gage.fillAmount - frontGage.gage.fillAmount) *
            m_damageCurve.Evaluate(m_gageManager.animeTime));
            backGage.gage.color = Color.red;
        };
        backGage.resetAction = () =>
        {
            backGage.gage.fillAmount = frontGage.gage.fillAmount;
        };

        //�A�j���[�V�����̏I������
        frontGage.finishTime = 0.0f;
        backGage.finishTime = 1.0f;

        //�^�C���X�P�[���̐ݒ�
        m_gageManager.timeScale = 0.5f;
    }
}
