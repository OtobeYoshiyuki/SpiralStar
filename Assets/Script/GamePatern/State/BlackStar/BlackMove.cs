using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMove : StateBase<BlackStar>
{
    /// <summary>
    /// �����������x�N�g��
    /// </summary>
    private Vector3 m_dir = Vector3.zero;

    /// <summary>
    /// BlackMove����BlackRotation�ւƈڍs���鎞��
    /// �萔
    /// </summary>
    public const float CHANGE_STATE = 3.0f;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public BlackMove() { }

    /// <summary>
    /// State�̎��s����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    public override void OnExecute(BlackStar owner) 
    {
        //�����G���W���̃x�N�g�����擾
        Vector2 vel = owner.rigidBody2D.velocity;

        //BlackStar����]������
        owner.rotAngle += new Vector3(0, 0, 4) * Mathf.Clamp(vel.magnitude, 0.0f, 7.0f);

        //�x�N�g���̒������ŏ��l���傫���Ƃ�
        if (vel.magnitude > Movement.MIN_MOVE_LIMIT)
        {
            //�x�N�g���𐳋K��
            vel.Normalize();

            //�x�N�g���𔽓]
            vel *= -1;

            //�����G���W���ŗ͂�������
            owner.rigidBody2D.AddForce(vel / 3, ForceMode2D.Force);
        }
        //�x�N�g���̒������ŏ��l�ȉ��̎�
        else
        {
            //�x�N�g�����[���ɂ���
            owner.rigidBody2D.velocity = Vector2.zero;
        }

        //State���ڍs���Ă���2�b�ȏ�o�߂��邩�A
        //SpiralStar�Ƃ̋��������ȏ㗣��Ă����
        if(owner.time >= CHANGE_STATE ||
            Utility.VectorLength(owner.rigidBody2D.position,
            owner.starPlayer.rigidBody2D.position) >= 1.0f)
        {
            //State��؂�ւ���
            owner.stateMachine.ChangeState(owner.blackRotation);

            //�ȍ~�̏����͔�΂�
            return;
        }

        //���Ԃ��X�V����
        owner.time += Time.deltaTime;

        Debug.Log(owner.rigidBody2D.velocity.magnitude * 5);

    }

    /// <summary>
    /// State�̊J�n����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="preState">�O��̃X�e�[�g</param>
    public override void OnEnter(BlackStar owner, StateBase<BlackStar> preState) 
    {
        //���Ԃ�����������
        owner.time = 0.0f;

        //�����G���W���ŗ͂�������
        owner.rigidBody2D.AddForce(m_dir * 5.0f, ForceMode2D.Impulse);
    }

    /// <summary>
    /// State���I������
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="nextState">����State</param>
    public override void OnExit(BlackStar owner, StateBase<BlackStar> nextState) { }

    /// <summary>
    /// �����������x�N�g��
    /// </summary>
    public Vector3 dir
    {
        get { return m_dir; }
        set { m_dir = value; }
    }
}
