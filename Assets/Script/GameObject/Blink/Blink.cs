using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �_�Ő���N���X
/// </summary>
[System.Serializable]
public class Blink
{
    /// <summary>
    /// �_�Œ��̃t���O
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private bool m_blink = false;

    /// <summary>
    /// �\�����̃t���O
    /// </summary>
    private bool m_draw = true;

    /// <summary>
    /// �_�ł̃��[�v�̐ݒ�p�̃t���O
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private bool m_loop = false;

    /// <summary>
    /// �_�Ŏ��Ԃ̌v���p�̕ϐ�
    /// </summary>
    private float m_blinkTime = 0.0f;

    /// <summary>
    /// �_�Œ��̃t���[����(DeltaTime�)
    /// </summary>
    private float m_frameCount = 0.0f;

    /// <summary>
    /// �_�ł̊Ԋu�p�̕ϐ�
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private float m_blinkInterval = 0.0f;

    /// <summary>
    /// �_�ł̍ő吔(���[�v�ݒ肪false�ɂȂ��Ă���Ƃ��̂ݗL��
    /// Inspecter����ҏW�ł���悤�ɂ���)
    /// </summary>
    [SerializeField]
    private float m_blinkLimit = 0.0f;

    /// <summary>
    /// �\�����ɌĂ΂��
    /// �֐��f���Q�[�g
    /// </summary>
    private event Action m_drawEnable = null;

    /// <summary>
    /// ��\�����ɌĂ΂��
    /// �֐��f���Q�[�g
    /// </summary>
    private event Action m_drawDisable = null;

    /// <summary>
    /// ���������ɌĂ΂��
    /// �֐��f���Q�[�g
    /// </summary>
    private event Action m_resetAction = null;

    public void Update()
    {
        //�_�ł������̏ꍇ
        if (!m_blink) return;

        //�_�Ŏ��Ԃ��o�߂����Ƃ�
        if (m_blinkTime >= m_blinkInterval)
        {
            //�r�b�g�𔽓]������
            m_draw = !m_draw;

            //�_�Ŏ��Ԃ�����������
            m_blinkTime = 0.0f;
        }

        //���[�v�ݒ肪false�̎�
        if(!m_loop)
        {
            //�_�Ŏ��Ԃ̏I���̎�
            if(m_frameCount >= m_blinkLimit)
            {
                //�_�ł�����������
                OnReset();

                //�ȍ~�̏����͔�΂�
                return;
            }
        }

        //�󋵂ɉ����Ċ֐����Ă�
        Action draw = m_draw ? m_drawEnable : m_drawDisable;
        draw?.Invoke();

        //�_�Ŏ��Ԃ��X�V����
        m_blinkTime += Time.deltaTime;

        //�t���[�������X�V����
        m_frameCount += Time.deltaTime;
    }

    /// <summary>
    /// �_�ł�����������
    /// </summary>
    public void OnReset()
    {
        //�_�ł𖳌��ɂ���
        m_blink = false;

        //�\�����I���ɂ���
        m_draw = true;

        //�_�Ŏ��Ԃ�����������
        m_blinkTime = 0.0f;

        //�t���[����������������
        m_frameCount = 0.0f;

        //�C�x���g�֐����Ă�
        m_resetAction?.Invoke();
    }

    /// <summary>
    /// �_�Œ��̃t���O
    /// �Q�b�^�[
    /// </summary>
    public bool blink 
    { 
        get { return m_blink; } 
        set { m_blink = value; }
    }

    /// <summary>
    /// �\�����̃t���O
    /// �Q�b�^�[
    /// </summary>
    public bool draw { get { return m_draw; } }

    /// <summary>
    /// �C�x���g�֐�
    /// �Z�b�^�[
    /// </summary>
    public Action drawEnable { set { m_drawEnable = value; } }

    /// <summary>
    /// �C�x���g�֐�
    /// �Z�b�^�[
    /// </summary>
    public Action drawDisable { set { m_drawDisable = value; } }

    /// <summary>
    /// �C�x���g�֐�
    /// �Z�b�^�[
    /// </summary>
    public Action resetAction { set { m_resetAction = value; } }
}
