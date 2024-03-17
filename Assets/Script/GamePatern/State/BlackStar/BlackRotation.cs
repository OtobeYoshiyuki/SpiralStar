using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRotation : StateBase<BlackStar>
{
    /// <summary>
    /// Player��Enemy�̊p�x�̍���}��
    /// </summary>
    private float m_angleDef = 0.0f;

    /// <summary>
    /// State�Ɉڍs�����ۂ̍ŏ��̊p�x�����߂�
    /// </summary>
    private float m_firstAngle = 0.0f;

    /// <summary>
    /// State���ڍs�����鎞��
    /// </summary>
    public const float STATE_TIME = 2.0f;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public BlackRotation() { }

    /// <summary>
    /// State�̎��s����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    public override void OnExecute(BlackStar owner) 
    {
        //StarManager���擾����
        StarManager starManager = StarManager.Instance;

        //�����G���W���̃x�N�g�����擾
        Vector2 vel = owner.rigidBody2D.velocity;

        //�x�N�g���̒������ŏ��l���傫���Ƃ�
        if (vel.magnitude > Movement.MIN_MOVE_LIMIT)
        {
            //�x�N�g���𐳋K��
            vel.Normalize();

            //�x�N�g���𔽓]
            vel *= -1;

            //�����G���W���ŗ͂�������
            owner.rigidBody2D.AddForce(vel, ForceMode2D.Force);

            //����Ǝ����̊p�x�̍����擾����
            m_angleDef = -Utility.Atan2DegAngle(owner.rigidBody2D.position, starManager.playerStar.rigidBody2D.position);
        }
        //�x�N�g���̒������ŏ��l�ȉ��̎�
        else
        {
            //�x�N�g�����[���ɂ���
            owner.rigidBody2D.velocity = Vector2.zero;
        }

        //���Ԃ��o�߂��Ă��Ȃ����
        if (owner.time < STATE_TIME)
        {
            //Star����]������
            owner.rotAngle = new Vector3(0.0f, 0.0f, Mathf.Lerp(m_firstAngle,m_angleDef,Mathf.Clamp(owner.time,0.0f,1.0f)));
        }
        //���Ԃ��o�߂�����
        else
        {
            //�x�N�g���̕��������߂�
            owner.blackMove.dir = Quaternion.Euler(0.0f,0.0f,m_angleDef) * Vector3.up;

            //State��؂�ւ���
            owner.stateMachine.ChangeState(owner.blackMove);

            //�ȍ~�̏����͔�΂�
            return;
        }

        //���Ԃ��X�V����
        owner.time += Time.deltaTime;
    }

    /// <summary>
    /// State�̊J�n����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="preState">�O��̃X�e�[�g</param>
    public override void OnEnter(BlackStar owner, StateBase<BlackStar> preState) 
    {
        //StarManager���擾����
        StarManager starManager = StarManager.Instance;

        //���Ԃ�����������
        owner.time = 0.0f;

        //State�Ɉڍs�����ۂ̍ŏ��̊p�x��������
        m_firstAngle = owner.rotAngle.z;

        //����Ǝ����̊p�x�̍����擾����
        m_angleDef = -Utility.Atan2DegAngle(owner.rigidBody2D.position, starManager.playerStar.rigidBody2D.position);
    }

    /// <summary>
    /// State���I������
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="nextState">����State</param>
    public override void OnExit(BlackStar owner, StateBase<BlackStar> nextState) { }
}
