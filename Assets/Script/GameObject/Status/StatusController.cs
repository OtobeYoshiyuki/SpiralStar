using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�e�[�^�X�̃R���g���[���[
/// </summary>
public class StatusController 
{
    /// <summary>
    /// �X�e�[�^�X�̘A�z�z��
    /// �ϓ�����X�e�[�^�X�̂݃A�N�Z�X�\(�ϓ����Ȃ����̂̓f�[�^�x�[�X���Ǘ����Ă���)
    /// </summary>
    private Dictionary<string, float> m_status = new Dictionary<string, float>();

    /// <summary>
    /// �ݒ肷��X�e�[�^�X��o�^����
    /// </summary>
    /// <param name="infos">�X�e�[�^�X�̏����������z��</param>
    public void AddStatuses(List<StatusInfo> infos)
    {
        foreach(StatusInfo info in infos)
        {
            //�Y������X�e�[�^�X��ݒ肷��
            m_status.Add(info.tag, info.status);
        }
    }

    /// <summary>
    /// �Ώۂ̃X�e�[�^�X��ݒ肷��
    /// </summary>
    /// <param name="key">�X�e�[�^�X��key</param>
    /// <param name="value">�X�e�[�^�X��value</param>
    public void SetTargetStatus(string key,float value) { m_status[key] = value; }

    /// <summary>
    /// �Ώۂ̃X�e�[�^�X���擾����
    /// </summary>
    /// <param name="key">�X�e�[�^�X��key</param>
    /// <returns>�X�e�[�^�X��Ԃ�</returns>
    public float GetTargetStatus(string key) { return m_status[key]; }
}
