using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Star�̃`���[�W����UI���Ǘ�����N���X
/// Game����1�������݂��Ȃ��̂ŁASingleton���p��
/// </summary>
public class StarChaegeUI : Singleton<StarChaegeUI>
{
    /// <summary>
    /// �`���[�W�̑ΏۂƂȂ�GameObject
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private GameObject m_skyChaegeStar = null;

    /// <summary>
    /// Text��Compoment������GameObject
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private GameObject m_speedTextObject = null;

    /// <summary>
    /// UIObject��ImageCompoment���i�[����ϐ�
    /// </summary>
    private Image m_chargeUI = null;

    /// <summary>
    /// TextObject��TextComponent���i�[����ϐ�
    /// </summary>
    private Text m_speedTextUI = null;

    /// <summary>
    /// �`���[�W�̍ő�l
    /// �萔
    /// </summary>
    public const float MAXCHARGE = 1.0f;

    /// <summary>
    /// �`���[�W�̏����l
    /// �萔
    /// </summary>
    public const float INITCHARGE = 0.0f;

    /// <summary>
    /// �ő�̌���
    /// �萔
    /// </summary>
    public const int MAX_NUMBER = 3;

    /// <summary>
    /// UI�ɕ\������Ă���ŏ��l�̑��x
    /// </summary>
    public const float MIN_SPEED = 3.0f;

    /// <summary>
    /// 1�t���[�����Ƃ�UI�ɕ\������Ă����
    /// </summary>
    private float m_power = 0.0f;

    /// <summary>
    /// �`���[�W���Ă���Ƃ��ɌĂ΂��
    /// </summary>
    public void OnCharge()
    {
        //�Q�[�W�̔䗦���ő�l�����̎�
        if(m_chargeUI.fillAmount < MAXCHARGE)
        {
            //�Q�[�W�̔䗦�����Z����
            m_chargeUI.fillAmount += Time.deltaTime;
        }
    }

    /// <summary>
    /// �`���[�W����A�{�^���������ꂽ��
    /// �Ă΂��
    /// </summary>
    public void OnReset()
    {
        //�Q�[�W������������
        m_chargeUI.fillAmount = INITCHARGE;
    }

    /// <summary>
    /// �e�L�X�g��\���p�ɉ��H���鏈��
    /// </summary>
    /// <param name="star">�C���X�^���X�̏��L��</param>
    public void ManufacturingText(SpiralStar star)
    {
        //���݂̃x�N�g�����擾�i�����G���W������j
        Vector2 vel = star.rigidBody2D.velocity;

        //�x�N�g���̒������擾
        m_power = vel.magnitude * 10;

        //���x�����ȉ��̂��͕̂\���������I��0�ɂ���
        m_speedTextUI.text = m_power > MIN_SPEED ? Utility.ValueCustomFrontString(m_power, "f0", MAX_NUMBER, "0") : "000";
    }

    /// <summary>
    /// ����������
    /// </summary>
    protected override void Init()
    {
        //ImageComponent���擾
        m_chargeUI = m_skyChaegeStar.GetComponent<Image>();

        //TextComponent���擾
        m_speedTextUI = m_speedTextObject.GetComponent<Text>();
    }

    /// <summary>
    /// �p������
    /// </summary>
    protected override void Release()
    {
    }


    /// <summary>
    /// ImageComponent���擾
    /// �Q�b�^�[
    /// </summary>
    public Image image { get { return m_chargeUI; } }

    /// <summary>
    /// TextComponent���擾
    /// �Q�b�^�[
    /// </summary>
    public Text cText { get { return m_speedTextUI; } }

    /// <summary>
    /// Player�̗͂��擾����
    /// </summary>
    public float power { get { return m_power; } }
}
