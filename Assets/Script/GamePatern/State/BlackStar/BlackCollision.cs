using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCollision : StateBase<BlackStar>
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BlackCollision() { }

    /// <summary>
    /// Stateの実行処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    public override void OnExecute(BlackStar owner)
    {
        //BlackStarのFactoryを取得する
        BlackStarFactory blackStarFactory = BlackStarFactory.Instance;

        //StarEffectのFactoryを取得する
        StarEffectFactory StarEffectFactory = StarEffectFactory.Instance;

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

            //GameObjectを消去する
            blackStarFactory.ReleaseBlackStar(owner.id);

#pragma warning disable CS0612 // 型またはメンバーが旧型式です
            //Effectを生成する
            StarEffectFactory.SpawnStarEffect(owner);
#pragma warning restore CS0612 // 型またはメンバーが旧型式です
        }

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
    }

    /// <summary>
    /// Stateが終了処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="nextState">次のState</param>
    public override void OnExit(BlackStar owner, StateBase<BlackStar> nextState) { }
}