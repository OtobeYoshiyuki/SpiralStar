using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// State�̊��N���X
/// �W�F�l���b�N�^
/// ����FStateBase���p�����Ȃ���΂Ȃ�Ȃ�
/// </summary>
public abstract class StateBase<T> where T : class
{
    /// <summary>
    /// State�̎��s����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    public virtual void OnExecute(T owner) { }

    /// <summary>
    /// State�̊J�n����
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="preState">�O��̃X�e�[�g</param>
    public virtual void OnEnter(T owner,StateBase<T> preState) { }

    /// <summary>
    /// State���I������
    /// </summary>
    /// <param name="owner">�C���X�^���X�̏��L��</param>
    /// <param name="nextState">����State</param>
    public virtual void OnExit(T owner,StateBase<T> nextState) { }
}
