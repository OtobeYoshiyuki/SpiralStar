using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanStar : BlackStar
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BalanStar():base()
    {
        //BlackRotationのインスタンスを生成
        m_rotateState = new BlackRotation();

        //BlackMoveのインスタンスを生成
        m_moveState = new BlackMove();

        //BlackCollisionのインスタンスを生成
        m_collisionState = new BlackCollision();
    }

    // Start is called before the first frame update
    void Start()
    {
        //初期化処理
        StarInit();

        //StateMachineのインスタンスを生成
        m_stateMachine = new StateMachine<BlackStar>(this, m_rotateState);
    }

    // Update is called once per frame
    void Update()
    {
        //更新処理
        StarUpdate();

        //StateMachineの更新
        m_stateMachine.UpdateState();
    }
}
