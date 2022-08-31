using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SpiralStar����]����State
/// StateBase���p��
/// �e���v���[�g�̕��́A�C���X�^���X�̏��L�҂�SpiralStar���w��
/// </summary>
public class SpiralMove : StateBase<SpiralStar>
{
    /// <summary>
    /// �����������x�N�g��
    /// </summary>
    private Vector3 m_dir = Vector3.zero;

    /// <summary>
    /// �x�N�g���̔{��
    /// </summary>
    private float m_scalar = 0.0f;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public SpiralMove() { }

    /// <summary>
    /// State�̎��s����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    public override void OnExecute(SpiralStar owner)
    {
        //�����G���W���̃x�N�g�����擾
        Vector2 vel = owner.rigidBody2D.velocity;

        //SpiralStar����]������
        owner.rotAngle += new Vector3(0,0,4) * Mathf.Clamp(vel.magnitude,0.0f,7.0f);

        //�x�N�g���̒������ŏ��l���傫���Ƃ�
        if (vel.magnitude > SpiralStar.MIN_MOVE_LIMIT)
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

        //Debug.Log(owner.rigidBody2D.velocity.magnitude * 10);
    }

    /// <summary>
    /// State�̊J�n����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="preState">�O��̃X�e�[�g</param>
    public override void OnEnter(SpiralStar owner, StateBase<SpiralStar> preState) 
    {
        //�����G���W���ŗ͂�������
        owner.rigidBody2D.AddForce(m_dir * m_scalar, ForceMode2D.Impulse);
    }

    /// <summary>
    /// State���I������
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="nextState">����State</param>
    public override void OnExit(SpiralStar owner, StateBase<SpiralStar> nextState) { }

    /// <summary>
    /// �����������x�N�g��
    /// �Z�b�^�[�@�Q�b�^�[
    /// </summary>
    public Vector3 Direct
    {
        get { return m_dir; }
        set { m_dir = value; }
    }

    /// <summary>
    /// �x�N�g���̔{��
    /// �Z�b�^�[�A�Q�b�^�[
    /// </summary>
    public float Scalar 
    {
        get { return m_scalar; }
        set { m_scalar = value; }
    }
}
