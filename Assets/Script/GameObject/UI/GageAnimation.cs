using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// �Q�[�W�̃A�j���[�V�����N���X
/// </summary>
public class GageAnimation
{
    /// <summary>
    /// �Ώۂ̃Q�[�W
    /// </summary>
    private Image m_targetGage = null;

    /// <summary>
    /// �A�j���[�V�����̏I������
    /// </summary>
    private float m_animeFinish = 0.0f;

    /// <summary>
    /// �֐��I�u�W�F�N�g
    /// </summary>
    private event Action m_imageAction = null;

    /// <summary>
    /// �֐��I�u�W�F�N�g
    /// </summary>
    private event Action m_resetAction = null;

    /// <summary>
    /// �Q�[�W�̍X�V���s��
    /// </summary>
    /// <param name="manager">�Q�[�W�̊Ǘ��N���X</param>
    /// <returns>�������Ԃ𒴂�����false �����Ă��Ȃ�������true</returns>
    public bool UpdateGage(GageManager manager)
    {
        //�������Ԃ𒴂�����
        if (manager.animeTime > m_animeFinish)
        {
            //���Z�b�g�p�̊֐��I�u�W�F�N�g�����s����
            m_resetAction?.Invoke();

            //�ȍ~�̏����͔�΂�
            return true;
        }

        //�ݒ肳��Ă���֐��I�u�W�F�N�g�����s����
        m_imageAction?.Invoke();

        //�������Ԃ��z���Ă��Ȃ�
        return false;
    }

    /// <summary>
    /// �Q�[�W��Image
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public Image gage
    {
        set { m_targetGage = value; }
        get { return m_targetGage; }
    }

    /// <summary>
    /// �֐��I�u�W�F�N�g
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public Action imageAction
    {
        get { return m_imageAction; }
        set { m_imageAction = value; }
    }

    /// <summary>
    /// �֐��I�u�W�F�N�g
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public Action resetAction
    {
        get { return m_resetAction; }
        set { m_resetAction = value; }
    }

    /// <summary>
    /// �A�j���[�V�����̏I������
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public float finishTime
    {
        set { m_animeFinish = value; }
        get { return m_animeFinish; }
    }
}
