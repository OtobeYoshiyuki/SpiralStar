using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlackStar�̊��N���X
/// </summary>
public abstract class BlackStar : StarBase
{
    /// <summary>
    /// �L��StateMachine
    /// </summary>
    protected StateMachine<BlackStar> m_stateMachine = null;

    /// <summary>
    /// BlackStar�̉�]��State
    /// </summary>
    protected BlackRotation m_rotateState = null;

    /// <summary>
    /// BlackStar�̈ړ���State
    /// </summary>
    protected BlackMove m_moveState = null;

    /// <summary>
    /// BlackStar�̏Փˎ���State
    /// </summary>
    protected BlackCollision m_collisionState = null;

    /// <summary>
    /// Player�̑��삷��Star�ɃA�N�Z�X���邽�߂̃N���X
    /// </summary>
    private SpiralStar m_playerStar = null;

    /// <summary>
    /// �L���������ʂ��邽�߂�ID
    /// </summary>
    private int m_id = 0;

    /// <summary>
    /// GameObject�ɐݒ肳��Ă���^�O
    /// </summary>
    public const string BLACKSTAR_TAG = "BlackStar";

    //�U�����󂯂��Ƃ��̃��C���[
    public const int COLLISION_LAYER = 7;

    //�R���X�g���N�^
    protected BlackStar() : base()
    {

    }

    /// <summary>
    /// ���̋��ʂ̏������Ă�
    /// </summary>
    //������
    public override void StarInit()
    {
        //���N���X�̏������Ă�
        base.StarInit();
    }

    //�X�V����
    public override void StarUpdate()
    {
        //���N���X�̏������Ă�
        base.StarUpdate();

        //���S�����Ƃ�
        if(deth)
        {
            //�X�e�[�g��ύX����
            m_stateMachine.ChangeState(blackCollision);

            //���C���[��ύX����
            gameObject.layer = COLLISION_LAYER;

            //�t���O�𗎂Ƃ�
            deth = false;
        }
    }

    //�I������
    public override void StarFinal()
    {
        //���N���X�̏������Ă�
        base.StarFinal();
    }

    /// <summary>
    /// StateMachine
    /// �Q�b�^�[�@
    /// </summary>
    public StateMachine<BlackStar> stateMachine
    {
        get { return m_stateMachine; }
    }

    /// <summary>
    /// BlackStar�̉�]�p��State
    /// �Q�b�^�[
    /// </summary>
    public BlackRotation blackRotation
    {
        get { return m_rotateState; }
    }

    /// <summary>
    /// BlackStar�̈ړ��p��State
    /// �Q�b�^�[
    /// </summary>
    public BlackMove blackMove
    {
        get { return m_moveState; }
    }

    /// <summary>
    /// BlackStar�̏Փ˗p��State
    /// �Q�b�^�[
    /// </summary>
    public BlackCollision blackCollision
    {
        get { return m_collisionState; }
    }

    /// <summary>
    /// SpiralStar�iPlayer�����삵�Ă���j
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public SpiralStar starPlayer
    {
        get { return m_playerStar; }
        set { m_playerStar = value; }
    }

    /// <summary>
    /// id�i���ʔԍ��j
    /// �Q�b�^�[�@�Z�b�^�[
    /// </summary>
    public int id
    {
        get { return m_id; }
        set { m_id = value; }
    }
}
