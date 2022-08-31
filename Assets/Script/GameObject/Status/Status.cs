using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusInfo
{
    /// <summary>
    /// �X�e�[�^�X�̖��O
    /// </summary>
    [SerializeField]
    private string m_tag = string.Empty;

    /// <summary>
    /// �X�e�[�^�X�̒l
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private float m_status = 0.0f;

    /// <summary>
    /// �^�O���擾����
    /// �Q�b�^�[
    /// </summary>
    public string tag { get { return m_tag; } }

    /// <summary>
    /// �X�e�[�^�X�̔z����擾����
    /// �Q�b�^�[
    /// </summary>
    public float status { get { return m_status; } }
}

/// <summary>
/// �X�^�[�̃X�e�[�^�X
/// </summary>
[System.Serializable]
public class StarStatus
{
    /// <summary>
    /// �X�e�[�^�X�̏��L�҂̃^�O
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private string m_ownerTag = string.Empty;

    /// <summary>
    /// �X�e�[�^�X�̃��X�g
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private List<StatusInfo> m_statusList = new List<StatusInfo>();

    /// <summary>
    /// ���L�҂̃^�O���擾����
    /// �Q�b�^�[
    /// </summary>
    public string owner { get { return m_ownerTag; } }

    /// <summary>
    /// �X�e�[�^�X�̃��X�g���擾����
    /// �Q�b�^�[
    /// </summary>
    public List<StatusInfo> statusList { get { return m_statusList; } }
}
