using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Star�̃`���[�W����UI���Ǘ�����N���X
/// Game����1�������݂��Ȃ��̂ŁASingleton���p��
/// </summary>
public class TimerUI : Singleton<TimerUI>
{
    /// <summary>
    /// TextComponent������GameObject
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private GameObject m_textObject = null;

    /// <summary>
    /// 60~0�b��\��GameObject
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private GameObject m_timerNormalObject = null;

    /// <summary>
    /// 120~60�b��\��GameObject
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private GameObject m_timerOverObject = null;

    /// <summary>
    /// TextObject��TextComponent���i�[����ϐ�
    /// </summary>
    private Text m_timerTextUI = null;

    /// <summary>
    /// ���݂̎��Ԃ�\���ϐ�
    /// </summary>
    private float m_time = 0.0f;

    /// <summary>
    /// ���Ԃ̌��E�n��\���ϐ��i60~120�j
    /// </summary>
    private float m_limitTime = 0.0f;

    /// <summary>
    /// �J�n���鎞��
    /// �萔
    /// </summary>
    public const float START_TIME = 60.0f;

    /// <summary>
    /// ���Ԃ̌��E�l�̍ő��\��
    /// �萔
    /// </summary>
    public const float MAX_LIMIT_TIME = 120.0f;

    /// <summary>
    /// �ő�̌���
    /// �萔
    /// </summary>
    public const int MAX_NUMBER = 3;

    /// <summary>
    /// �^�C�}�[�̏I�������m����t���O
    /// </summary>
    private bool m_finishTimer = false;

    /// <summary>
    /// �^�C�}�[���X�V����t���O
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private bool m_updateTimer = false;

    // Update is called once per frame
    void Update()
    {
        //ImageComponent�̏�����
        Image timerImage = null;

        //�䗦�����߂�ϐ��̏�����
        float ratio = 0.0f;

        //�I���t���O���I���̎��A�ȍ~�̏����͔�΂�
        if (m_finishTimer) return;

        //���݂̎��Ԃ�61~120�b�̊Ԃ̎�
        if (m_time <= MAX_LIMIT_TIME && m_time > START_TIME)
        {
            //ImageComponent���擾����
            timerImage = m_timerOverObject.GetComponent<Image>();

            //���Ԃ̔䗦���擾����
            ratio = m_time / MAX_LIMIT_TIME;
        }
        //���݂̎��Ԃ�0~60�b�̊Ԃ̎�
        else
        {
            //ImageComponent���擾����
            timerImage = m_timerNormalObject.GetComponent<Image>();

            //���Ԃ̔䗦���擾����
            ratio = m_time / START_TIME;
        }

        //���Ԃ��X�V����
        m_time -= Time.deltaTime;

        //�������Ԃ��؂ꂽ��
        if (m_time < 0.0f)
        {
            //���Ԃ��[���ɂ���
            m_time = 0.0f;

            //�I���t���O���N����
            m_finishTimer = true;

        }
        //�^�C�}�[��UI���X�V����
        timerImage.fillAmount = ratio;

        //���݂̎��Ԃ��X�V����
        m_timerTextUI.text = Utility.ValueCustomFrontString(m_time, "f0", MAX_NUMBER, "0");
    }

    /// <summary>
    /// ����������
    /// </summary>
    protected override void Init() 
    {
        //TextComponent���擾
        m_timerTextUI = m_textObject.GetComponent<Text>();

        //���Ԃ�����������
        m_time = START_TIME;
        m_limitTime = START_TIME;

        //�����t���O��ݒ肷��
        m_finishTimer = false;
    }

    /// <summary>
    /// �p������
    /// </summary>
    protected override void Release() 
    { 
    }

}
