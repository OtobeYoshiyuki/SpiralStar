using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanStar : BlackStar
{

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public BalanStar():base()
    {
        //BlackRotation�̃C���X�^���X�𐶐�
        m_rotateState = new BlackRotation();

        //BlackMove�̃C���X�^���X�𐶐�
        m_moveState = new BlackMove();

        //BlackCollision�̃C���X�^���X�𐶐�
        m_collisionState = new BlackCollision();
    }

    // Start is called before the first frame update
    void Start()
    {
        //����������
        StarInit();

        //StateMachine�̃C���X�^���X�𐶐�
        m_stateMachine = new StateMachine<BlackStar>(this, m_rotateState);
    }

    // Update is called once per frame
    void Update()
    {
        //�X�V����
        StarUpdate();

        //StateMachine�̍X�V
        m_stateMachine.UpdateState();
    }
}
