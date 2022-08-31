using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SpiralStar����]����State
/// StateBase���p��
/// �e���v���[�g�̕��́A�C���X�^���X�̏��L�҂�SpiralStar���w��
/// </summary>
public class SpiralRotation : StateBase<SpiralStar>
{
    /// <summary>
    /// ���𐶐�����t���O
    /// </summary>
    private bool m_fArrowCreate = false;

    /// <summary>
    /// �I�u�W�F�N�g�̉�]�����鑬�x
    /// �萔�@�Q�b�^�[
    /// </summary>
    public static Vector3 ROTSPEED { get { return new Vector3(0.0f, 0.0f, 15.0f); } }

    /// <summary>
    /// ����������̑��΍��W
    /// </summary>
    public static Vector3 RELATIVEARROW { get { return new Vector3(0.0f, 0.25f, 0.0f); } }

    /// <summary>
    /// 180~360�x�̕␳�l���擾
    /// �萔
    /// </summary>
    public const float MINUSANGLE = 180.0f;

    /// <summary>
    /// ���̍��W�̏C��
    /// �萔
    /// </summary>
    public const float CALCARROW_LOCATION = 0.25f;

    /// <summary>
    /// �����̊p�x
    /// �萔
    /// </summary>
    public const float RIGHT_ANGLE = 90.0f;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public SpiralRotation() { }

    /// <summary>
    /// State�̎��s����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    public override void OnExecute(SpiralStar owner) 
    {
        //GamePad�̍��X�e�B�b�N�̓��͂��擾����
        Vector2 move = owner.actions.Player.Move.ReadValue<Vector2>();

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
            owner.rigidBody2D.AddForce(vel * 3, ForceMode2D.Force);
        }
        //�x�N�g���̒������ŏ��l�ȉ��̎�
        else
        {
            //�x�N�g�����[���ɂ���
            owner.rigidBody2D.velocity = Vector2.zero;
        }

        //GamePad��A�{�^���������ꂽ���ǂ���
        if (owner.actions.Player.Atack.IsPressed())
        {
            //SpiralStar����]������
            owner.rotAngle += ROTSPEED;

            //�Q�[�W�̃`���[�W���s��
            StarChaegeUI.Instance.OnCharge();

            //���̃C���X�^���X�𐶐�����
            OnArrowInstantiate(owner);
        }

        //GamePad��A�{�^���������ꂽ��
        if(owner.actions.Player.Atack.WasReleasedThisFrame())
        {
            //�`���[�WUI����摜���擾
            Image image = StarChaegeUI.Instance.image;

            //�`���[�W��AnimationCurve���x�N�g���̔{���ɐݒ�
            owner.spiralMove.Scalar = owner.curve.Evaluate(image.fillAmount);

            //�L�[�̓��͏�Ԃɂ���Ĉړ�������ς���
            owner.spiralMove.Direct = move == Vector2.zero ? Vector2.up : move;

            //�Q�[�W�̏��������s��
            StarChaegeUI.Instance.OnReset();

            //State��؂�ւ���
            owner.stateMachine.ChangeState(owner.spiralMove);

            //�Ȍ�̏����͔�΂�
            return;
        }

        //���X�e�B�b�N�̓��͂��������Ƃ�
        if (owner.actions.Player.Move.IsPressed())
        {
            //���̃C���X�^���X�𐶐�����
            OnArrowInstantiate(owner);

            //��󂪐�������Ă���ꍇ
            if (owner.arrow)
            {
                //���̉�]�p�x�����߂�
                float radian = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;

                //���̍��W���Đݒ肷��
                owner.arrow.transform.position = new Vector3(move.x * 0.25f, move.y * 0.25f,0.0f) + 
                    new Vector3(owner.rigidBody2D.position.x, owner.rigidBody2D.position.y,0.0f);
                
                //�p�x���Đݒ肷��
                owner.arrow.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -radian));
            }
        }

        //���X�e�B�b�N�������ꂽ�Ƃ�
        if (owner.actions.Player.Move.WasReleasedThisFrame())
        {
            //���̃C���X�^���X���폜����
            OnArrowRelease(owner);
        }
    }

    /// <summary>
    /// State�̊J�n����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="preState">�O��̃X�e�[�g</param>
    public override void OnEnter(SpiralStar owner, StateBase<SpiralStar> preState) 
    {
        //���̐����̃t���O��؂�
        m_fArrowCreate = false;
    }

    /// <summary>
    /// State���I������
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="nextState">����State</param>
    public override void OnExit(SpiralStar owner, StateBase<SpiralStar> nextState) 
    {
        //���̃C���X�^���X���폜����
        OnArrowRelease(owner);
    }

    /// <summary>
    /// ���̃C���X�^���X�𐶐�����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    public void OnArrowInstantiate(SpiralStar owner)
    {
        //�����t���O��false�̂Ƃ�
        if (!m_fArrowCreate)
        {
            //���̃C���X�^���X�𐶐�����
            ArrowFactory.Instance.CreateArrow(owner, RELATIVEARROW);

            //�t���O���N����
            m_fArrowCreate = true;
        }
    }

    /// <summary>
    /// ���̃C���X�^���X���폜����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    public void OnArrowRelease(SpiralStar owner)
    {
        //�����t���O��true�̂Ƃ�
        if (m_fArrowCreate)
        {
            //���̃C���X�^���X���폜����
            ArrowFactory.Instance.ReleaseArrow(owner);

            //�t���O��؂�
            m_fArrowCreate = false;
        }
    }
}
