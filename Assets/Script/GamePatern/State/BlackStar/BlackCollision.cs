using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCollision : StateBase<BlackStar>
{
    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public BlackCollision() { }

    /// <summary>
    /// State�̎��s����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    public override void OnExecute(BlackStar owner)
    {
        //BlackStar��Factory���擾����
        BlackStarFactory blackStarFactory = BlackStarFactory.Instance;

        //StarEffect��Factory���擾����
        StarEffectFactory StarEffectFactory = StarEffectFactory.Instance;

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

            //GameObject����������
            blackStarFactory.ReleaseBlackStar(owner.id);

#pragma warning disable CS0612 // �^�܂��̓����o�[�����^���ł�
            //Effect�𐶐�����
            StarEffectFactory.SpawnStarEffect(owner);
#pragma warning restore CS0612 // �^�܂��̓����o�[�����^���ł�
        }

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
    }

    /// <summary>
    /// State���I������
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="nextState">����State</param>
    public override void OnExit(BlackStar owner, StateBase<BlackStar> nextState) { }
}