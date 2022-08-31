using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�e�[�^�X�̊Ǘ��N���X
/// </summary>
[System.Serializable]
public class StatusManager : Singleton<StatusManager>
{
    /// <summary>
    /// �X�e�[�^�X�̃f�[�^�x�[�X
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private StatusDataBase m_dataBase = new StatusDataBase();

    /// <summary>
    /// �X�e�[�^�X�̃��X�g
    /// �Q�[�����ɒl���ϓ�������̂̂ݐݒ肷��
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private List<StarStatus> m_statusList = new List<StarStatus>();

    /// <summary>
    /// �X�^�[���Ƃ̃X�e�[�^�X�̘A�z�z��
    /// �Q�[�����ɒl���ϓ�������̂̂ݐݒ�
    /// </summary>
    private Dictionary<string, List<StatusInfo>> m_starStatusList = new Dictionary<string, List<StatusInfo>>();

    /// <summary>
    /// ����������
    /// </summary>
    protected override void Init()
    {
        //�f�[�^�x�[�X�̏��������s��
        m_dataBase.InitDataBase();

        foreach(StarStatus status in m_statusList)
        {
            //Inspecter�Őݒ肵���X�e�[�^�X��A�z�z��ɓo�^����
            m_starStatusList.Add(status.owner, status.statusList);
        }
    }

    /// <summary>
    /// �p������
    /// </summary>
    protected override void Release()
    {
    }

    public void OnDamageStatus(StatusController self,StatusController other)
    {
        //�_���[�W�v�Z���s��
        float newHP = CaclHpStatus(
            self.GetTargetStatus(StarBase.HP),//���g��HP���1�����ɐݒ�
            other.GetTargetStatus(StarBase.ATACK),//����̍U���͂��2������
            dataBase.MaxStatus(StarBase.DEFENCE)//����̎���͂��3������
            );

        //�V����HP���Đݒ肷��
        self.SetTargetStatus(StarBase.HP, newHP);

    }

    /// <summary>
    /// �X�e�[�^�X�Ƀ_���[�W��^����
    /// </summary>
    /// <param name="hp">�̗�</param>
    /// <param name="atack">�U����</param>
    /// <param name="defence">�h���</param>
    /// <returns>�V���ȑ̗�</returns>
    public float CaclHpStatus(float hp,float atack,float defence)
    {
        //�p�����[�^�[����V����HP���Z�o����
        return hp - (atack - defence);
    }

    /// <summary>
    /// �X�e�[�^�X�p�̃f�[�^�x�[�X���擾
    /// �Q�b�^�[
    /// </summary>
    public StatusDataBase dataBase { get { return m_dataBase; } }

    /// <summary>
    /// �X�e�[�^�X�̔z����擾����
    /// </summary>
    /// <param name="key">�X�e�[�^�X�̏��L�҂̃^�O</param>
    /// <returns>�Y������X�e�[�^�X�̔z��</returns>
    public List<StatusInfo> GetStatusInfoArray(string key) { return m_starStatusList[key]; }
}
