using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SpiralStar���Փ˂���State
/// StateBase���p��
/// �e���v���[�g�̕��́A�C���X�^���X�̏��L�҂�SpiralStar���w��
/// </summary>
public class SpiralCollision : StateBase<SpiralStar>
{
    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public SpiralCollision() { }

    /// <summary>
    /// State�̎��s����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    public override void OnExecute(SpiralStar owner)
    {
    }

    /// <summary>
    /// State�̊J�n����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="preState">�O��̃X�e�[�g</param>
    public override void OnEnter(SpiralStar owner, StateBase<SpiralStar> preState)
    {
    }

    /// <summary>
    /// State���I������
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="nextState">����State</param>
    public override void OnExit(SpiralStar owner, StateBase<SpiralStar> nextState) { }
}
