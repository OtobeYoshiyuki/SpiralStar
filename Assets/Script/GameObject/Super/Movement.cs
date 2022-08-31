using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    //�I�u�W�F�N�g�̉�]�l
    protected Vector3 m_rotAngle = Vector3.zero;

    //�I�u�W�F�N�g���ړ�������X�s�[�h
    protected Vector3 m_moveSpeed = Vector3.zero;

    //�I�u�W�F�N�g���X�P�[�����O������X�s�[�h
    protected Vector3 m_scaleSpeed = Vector3.zero;

    /// <summary>
    /// RigidBody2D��Component
    /// </summary>
    protected Rigidbody2D m_rigidBody2D = null;

    /// <summary>
    /// CirCle��Collider
    /// �����蔻��
    /// </summary>
    protected CircleCollider2D m_circleCollider2D = null;

    /// <summary>
    /// �����G���W������͂�������ŏ��l
    /// </summary>
    public const float MIN_MOVE_LIMIT = 0.03f;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    protected Movement()
    {

    }

   //�ړ�����
   public void Move()
    {
        //�I�u�W�F�N�g���ړ�������
        transform.position += m_moveSpeed;
    }

    //��]����
    public void Rotation()
    {
        //�I�u�W�F�N�g���w�肵���l�ɉ�]������
        transform.rotation = Quaternion.Euler(m_rotAngle);
    }

    //�g��k��
    public void Scaling()
    {

    }

    /// <summary>
    /// ��]�̒l
    /// �Q�b�^�[�A�Z�b�^�[
    /// </summary>
    public Vector3 rotAngle
    {
        get { return m_rotAngle; }
        set { m_rotAngle = value; }
    }

    /// <summary>
    /// 1�t���[���Ɉړ�������l
    /// �Q�b�^�[�A�Z�b�^�[
    /// </summary>
    public Vector3 moveSpeed
    {
        get { return m_moveSpeed; }
        set { m_moveSpeed = value; }
    }

    /// <summary>
    /// RigidBody2D���擾����
    /// �Q�b�^�[
    /// </summary>
    public Rigidbody2D rigidBody2D
    {
        get { return m_rigidBody2D; }
    }

    /// <summary>
    /// CircleCollider2D
    /// �Q�b�^�[
    /// </summary>
    public CircleCollider2D circle2D
    {
        get { return m_circleCollider2D; }
    }
}
