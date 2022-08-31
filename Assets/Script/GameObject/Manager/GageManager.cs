using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[�W�̊Ǘ��N���X
/// </summary>
public class GageManager
{
    /// <summary>
    /// �A�j���[�V���������s�����ǂ���
    /// </summary>
    private bool m_isAnimation = false;

    /// <summary>
    /// �A�j���[�V�����̌v������
    /// </summary>
    private float m_animeTime = 0.0f;

    /// <summary>
    /// �^�C���X�P�[��
    /// </summary>
    private float m_timeScale = 1.0f;

    /// <summary>
    /// �Q�[�W�̃A�j���[�V�����̃��X�g
    /// </summary>
    private List<GageAnimation> m_animationList = new List<GageAnimation>();

    /// <summary>
    /// �A�j���[�V�����̊Ǘ��N���X�̏�����
    /// </summary>
    public void InitGageManager()
    {
        //�A�j���[�V�����t���O�𗎂Ƃ�
        m_isAnimation = false;

        //�A�j���[�V�����̌v�����Ԃ�����������
        m_animeTime = 0.0f;
    }

    /// <summary>
    /// �A�j���[�V�����̊Ǘ��N���X�̍X�V����
    /// </summary>
    public void UpdateGageManager()
    {
        //�A�j���[�V�����t���O�������Ă���Ƃ��͉������Ȃ�
        if (!m_isAnimation) return;

        //�A�j���[�V�����̏I�����J�E���g����ϐ���錾����
        int animeFinish = 0;

        foreach(GageAnimation animation in m_animationList)
        {
            //�A�j���[�V�������I���������m�F����
            bool result = animation.UpdateGage(this);

            //�I�����Ă�����A�J�E���g���X�V����
            if (result) animeFinish++;

            //�A�j���[�V���������ׂďI��������
            if(animeFinish >= m_animationList.Count)
            {
                //�t���O�ƃ^�C�}�[�̍X�V���s��
                InitGageManager();
            }
            //�A�j���[�V�������I����ĂȂ����
            else
            {
                //�A�j���[�V�������Ԃ̍X�V���s��
                m_animeTime += Time.deltaTime * m_timeScale;
            }
        }
    }

    /// <summary>
    /// �Ώۂ̃A�j���[�V�����Q�[�W���擾����
    /// </summary>
    /// <param name="index">�Ώۂ̃C���f�b�N�X</param>
    /// <returns>�Ώۂ̃A�j���[�V�����Q�[�W</returns>
    public GageAnimation GetGageAnimation(int index) { return m_animationList[index]; }

    /// <summary>
    /// �z��ɃA�j���[�V������ǉ�����
    /// </summary>
    /// <param name="gage">�ǉ�����Q�[�W</param>
    public void AddGage(GageAnimation gage) { m_animationList.Add(gage); }

    /// <summary>
    /// �A�j���[�V���������s�����m�F����t���O
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public bool isAnimation 
    { 
        get { return m_isAnimation; }
        set { m_isAnimation = value; }
    }

    /// <summary>
    /// �A�j���[�V�����̌v������
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public float animeTime 
    { 
        get { return m_animeTime; }
        set { m_animeTime = value; }
    }

    /// <summary>
    /// �A�j���[�V�����̍X�V���x�̃X�J��
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public float timeScale
    {
        get { return m_timeScale; }
        set { m_timeScale = value; }
    }
}
