using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�R�A�N���X
/// </summary>
public class Score
{
    /// <summary>
    /// ���݂̃X�R�A
    /// </summary>
    private float m_nowScore = 0.0f;

    /// <summary>
    /// �v�Z�O�̃X�R�A
    /// </summary>
    private float m_beforeScore = 0.0f;

    /// <summary>
    /// �v�Z��̃X�R�A
    /// </summary>
    private float m_afterScore = 0.0f;

    /// <summary>
    /// �X�R�A�̏���������
    /// </summary>
    /// <param name="now">���݂̃X�R�A</param>
    /// <param name="before">�v�Z�O�̃X�R�A</param>
    /// <param name="after">�v�Z��̃X�R�A</param>
    public void InitScore(float now,float before,float after)
    {
        //���݂̃X�R�A��ݒ肷��
        m_nowScore = now;

        //�v�Z�O�̃X�R�A��ݒ肷��
        m_beforeScore = before;

        //�v�Z��̃X�R�A��ݒ肷��
        m_afterScore = after;
    }

    /// <summary>
    /// �X�R�A�̍X�V����
    /// </summary>
    /// <param name="ownew">���L��</param>
    /// <returns>�v�Z���̎���true �v�Z���I������Ƃ���false</returns>
    public bool UpdateScore(ScoreController ownew)
    {
        //m_nowScore = Mathf.Clamp()

        //�v�Z���Ȃ̂�true��Ԃ�
        return true;
    }

    /// <summary>
    /// ���݂̃X�R�A
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public float now
    {
        set { m_nowScore = value; }
        get { return m_nowScore; }
    }

    /// <summary>
    /// �v�Z�O�̃X�R�A
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public float before
    {
        set { m_beforeScore = value; }
        get { return m_beforeScore; }
    }

    /// <summary>
    /// �v�Z��̃X�R�A
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public float after
    {
        set { m_afterScore = value; }
        get { return m_afterScore; }
    }
}
