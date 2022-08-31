using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMove : StateBase<BlackStar>
{
    /// <summary>
    /// 向きを示すベクトル
    /// </summary>
    private Vector3 m_dir = Vector3.zero;

    /// <summary>
    /// BlackMoveからBlackRotationへと移行する時間
    /// 定数
    /// </summary>
    public const float CHANGE_STATE = 3.0f;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BlackMove() { }

    /// <summary>
    /// Stateの実行処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    public override void OnExecute(BlackStar owner) 
    {
        //物理エンジンのベクトルを取得
        Vector2 vel = owner.rigidBody2D.velocity;

        //BlackStarを回転させる
        owner.rotAngle += new Vector3(0, 0, 4) * Mathf.Clamp(vel.magnitude, 0.0f, 7.0f);

        //ベクトルの長さが最小値より大きいとき
        if (vel.magnitude > Movement.MIN_MOVE_LIMIT)
        {
            //ベクトルを正規化
            vel.Normalize();

            //ベクトルを反転
            vel *= -1;

            //物理エンジンで力を加える
            owner.rigidBody2D.AddForce(vel / 3, ForceMode2D.Force);
        }
        //ベクトルの長さが最小値以下の時
        else
        {
            //ベクトルをゼロにする
            owner.rigidBody2D.velocity = Vector2.zero;
        }

        //Stateを移行してから2秒以上経過するか、
        //SpiralStarとの距離が一定以上離れていれば
        if(owner.time >= CHANGE_STATE ||
            Utility.VectorLength(owner.rigidBody2D.position,
            owner.starPlayer.rigidBody2D.position) >= 1.0f)
        {
            //Stateを切り替える
            owner.stateMachine.ChangeState(owner.blackRotation);

            //以降の処理は飛ばす
            return;
        }

        //時間を更新する
        owner.time += Time.deltaTime;

        Debug.Log(owner.rigidBody2D.velocity.magnitude * 5);

    }

    /// <summary>
    /// Stateの開始処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="preState">前回のステート</param>
    public override void OnEnter(BlackStar owner, StateBase<BlackStar> preState) 
    {
        //時間を初期化する
        owner.time = 0.0f;

        //物理エンジンで力を加える
        owner.rigidBody2D.AddForce(m_dir * 5.0f, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Stateが終了処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="nextState">次のState</param>
    public override void OnExit(BlackStar owner, StateBase<BlackStar> nextState) { }

    /// <summary>
    /// 方向を示すベクトル
    /// </summary>
    public Vector3 dir
    {
        get { return m_dir; }
        set { m_dir = value; }
    }
}
