using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�e�[�^�X�̃f�[�^�x�[�X
/// </summary>
[System.Serializable]
public class StatusDataBase
{
    /// <summary>
    /// �X�e�[�^�X�̃f�[�^�x�[�X
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private List<StatusInfo> m_infoList = new List<StatusInfo>();

    /// <summary>
    /// �X�e�[�^�X�̍ő�l�̘A�z�z��
    /// </summary>
    private Dictionary<string, float> m_maxStatusList = new Dictionary<string, float>();

    /// <summary>
    /// �X�e�[�^�X�̃f�[�^�x�[�X�̏�����
    /// </summary>
    public void InitDataBase()
    {
        foreach(StatusInfo info in m_infoList)
        {
            //�f�[�^�x�[�X�̔z��̒��g��A�z�z��ɐݒ肷��
            m_maxStatusList.Add(info.tag, info.status);
        }
    }

    /// <summary>
    /// �w�肵��key�̃X�e�[�^�X���擾����
    /// </summary>
    /// <param name="key">�A�z�z���key</param>
    /// <returns>�w�肵���X�e�[�^�X</returns>
    public float MaxStatus(string key) { return m_maxStatusList[key]; }
}
