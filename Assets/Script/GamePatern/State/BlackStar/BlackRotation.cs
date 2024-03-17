using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRotation : StateBase<BlackStar>
{
    /// <summary>
    /// PlayerとEnemyの角度の差を図る
    /// </summary>
    private float m_angleDef = 0.0f;

    /// <summary>
    /// Stateに移行した際の最初の角度を求める
    /// </summary>
    private float m_firstAngle = 0.0f;

    /// <summary>
    /// Stateを移行させる時間
    /// </summary>
    public const float STATE_TIME = 2.0f;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BlackRotation() { }

    /// <summary>
    /// Stateの実行処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    public override void OnExecute(BlackStar owner) 
    {
        //StarManagerを取得する
        StarManager starManager = StarManager.Instance;

        //物理エンジンのベクトルを取得
        Vector2 vel = owner.rigidBody2D.velocity;

        //ベクトルの長さが最小値より大きいとき
        if (vel.magnitude > Movement.MIN_MOVE_LIMIT)
        {
            //ベクトルを正規化
            vel.Normalize();

            //ベクトルを反転
            vel *= -1;

            //物理エンジンで力を加える
            owner.rigidBody2D.AddForce(vel, ForceMode2D.Force);

            //相手と自分の角度の差を取得する
            m_angleDef = -Utility.Atan2DegAngle(owner.rigidBody2D.position, starManager.playerStar.rigidBody2D.position);
        }
        //ベクトルの長さが最小値以下の時
        else
        {
            //ベクトルをゼロにする
            owner.rigidBody2D.velocity = Vector2.zero;
        }

        //時間が経過していなければ
        if (owner.time < STATE_TIME)
        {
            //Starを回転させる
            owner.rotAngle = new Vector3(0.0f, 0.0f, Mathf.Lerp(m_firstAngle,m_angleDef,Mathf.Clamp(owner.time,0.0f,1.0f)));
        }
        //時間が経過したら
        else
        {
            //ベクトルの方向を決める
            owner.blackMove.dir = Quaternion.Euler(0.0f,0.0f,m_angleDef) * Vector3.up;

            //Stateを切り替える
            owner.stateMachine.ChangeState(owner.blackMove);

            //以降の処理は飛ばす
            return;
        }

        //時間を更新する
        owner.time += Time.deltaTime;
    }

    /// <summary>
    /// Stateの開始処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="preState">前回のステート</param>
    public override void OnEnter(BlackStar owner, StateBase<BlackStar> preState) 
    {
        //StarManagerを取得する
        StarManager starManager = StarManager.Instance;

        //時間を初期化する
        owner.time = 0.0f;

        //Stateに移行した際の最初の角度を代入する
        m_firstAngle = owner.rotAngle.z;

        //相手と自分の角度の差を取得する
        m_angleDef = -Utility.Atan2DegAngle(owner.rigidBody2D.position, starManager.playerStar.rigidBody2D.position);
    }

    /// <summary>
    /// Stateが終了処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="nextState">次のState</param>
    public override void OnExit(BlackStar owner, StateBase<BlackStar> nextState) { }
}
