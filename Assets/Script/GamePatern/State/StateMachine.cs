using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �L��StateMachine
/// �W�F�l���b�N�^�i�e���v���[�g�ɂ�State�̏��L�҂̌^������j
/// </summary>
/// <typeparam name="T">StateBase���p�������^������</typeparam>
public class StateMachine<T> where T : class
{
    //State�̏��L��
    private T m_owner = null;

    //���݂�State
    private StateBase<T> m_currentState = null;

    //1�O��State
    private StateBase<T> m_preState = null;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public StateMachine(T owner,StateBase<T> newState)
    {
        //�C���X�^���X�̏��L�҂�ݒ�i�������ȗ����邽�߁j
        m_owner = owner;

        //���݂�State��ݒ�
        m_currentState = newState;

        //���݂�State�̊J�n����
        m_currentState?.OnEnter(m_owner, m_preState);
    }

    /// <summary>
    /// �L��StateMachine�̍X�V
    /// </summary>
    public void UpdateState()
    {
        //���݂�State�����s
        m_currentState?.OnExecute(m_owner);
    }

    /// <summary>
    /// State��؂�ւ���
    /// </summary>
    /// <param name="nextState">�V�����ݒ肷��State</param>
    public void ChangeState(StateBase<T> nextState)
    {
        //���݂�State�̏I�������i�����Ɏ���State��n���j
        m_currentState?.OnExit(m_owner, nextState);

        //���̃X�e�[�g�̊J�n�����i������1�O��State��n���j
        nextState?.OnEnter(m_owner, m_currentState);

        //1�O��State��ݒ肷��
        m_preState = m_currentState;

        //���݂�State��ݒ肷��
        m_currentState = nextState;
    }

    /// <summary>
    /// ���݂�State���擾
    /// </summary>
    public StateBase<T> currentState { get { return m_currentState; } }

    /// <summary>
    /// 1�O��State���擾
    /// </summary>
    public StateBase<T> preState { get { return m_preState; } }

}
