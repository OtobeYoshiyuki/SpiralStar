using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���̃C���^�[�t�F�[�X
/// </summary>
public interface IStarBase
{
    //������
    public void StarInit();

    //�X�V����
    public void StarUpdate();

    //�I������
    public void StarFinal();
}


/// <summary>
/// ���̊��N���X
/// </summary>
public abstract class StarBase : Movement, IStarBase
{
    /// <summary>
    /// HP�X�e�[�^�X��key
    /// �萔
    /// </summary>
    public const string HP = "Hp";

    /// <summary>
    /// Atack�X�e�[�^�X��key
    /// �萔
    /// </summary>
    public const string ATACK = "Atack";

    /// <summary>
    /// Defence�X�e�[�^�X��key
    /// �萔
    /// </summary>
    public const string DEFENCE = "Defence";

    /// <summary>
    /// State�̎��Ԃ��v�����鎞��
    /// </summary>
    private float m_time = 0.0f;

    /// <summary>
    /// Star�̏Փ˂��`�F�b�N����t���O
    /// </summary>
    private bool m_damageCheck = false;

    /// <summary>
    /// �L���������ꂽ�����`�F�b�N����t���O
    /// </summary>
    private bool m_dethCheck = false;

    /// <summary>
    /// �X�e�[�^�X�̃R���g���[���[
    /// </summary>
    private StatusController m_statusCs = new StatusController();

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    protected StarBase() : base()
    {

    }

    //������
    public virtual void StarInit()
    {
        //RigidBody2D���擾����
        m_rigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        //CircleCollider2D���擾����
        m_circleCollider2D = gameObject.GetComponent<CircleCollider2D>();

        //StatusManager���擾����
        StatusManager statusManager = StatusManager.Instance;

        //���g�̃X�e�[�^�X�̏����擾����
        List<StatusInfo> infos = statusManager.GetStatusInfoArray(gameObject.tag);

        //�X�e�[�^�X���R���g���[���[�ɓn��
        m_statusCs.AddStatuses(infos);
    }

    //�X�V����
    public virtual void StarUpdate()
    {
        //�ړ�����
        Move();

        //��]����
        Rotation();

        //�g��k������
        Scaling();
    }

    //�I������
    public virtual void StarFinal()
    {

    }

    /// <summary>
    /// State�̎��Ԃ��Ǘ�����
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public float time
    {
        get { return m_time; }
        set { m_time = value; }
    }

    /// <summary>
    /// �_���[�W�p�̃t���O���Ǘ�����
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public bool damage
    {
        get { return m_damageCheck; }
        set { m_damageCheck = value; }
    }

    /// <summary>
    /// ���S�p�̃t���O���Ǘ�����
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public bool deth
    {
        get { return m_dethCheck; }
        set { m_dethCheck = value; }
    }

    /// <summary>
    /// �X�e�[�^�X�̃R���g���[���[���擾����
    /// �Q�b�^�[
    /// </summary>
    public StatusController statusCs { get { return m_statusCs; } }
}