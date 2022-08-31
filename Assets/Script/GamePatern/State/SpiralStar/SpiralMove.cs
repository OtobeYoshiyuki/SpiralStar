using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SpiralStarが回転するState
/// StateBaseを継承
/// テンプレートの方は、インスタンスの所有者のSpiralStarを指定
/// </summary>
public class SpiralMove : StateBase<SpiralStar>
{
    /// <summary>
    /// 方向を示すベクトル
    /// </summary>
    private Vector3 m_dir = Vector3.zero;

    /// <summary>
    /// ベクトルの倍率
    /// </summary>
    private float m_scalar = 0.0f;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public SpiralMove() { }

    /// <summary>
    /// Stateの実行処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    public override void OnExecute(SpiralStar owner)
    {
        //物理エンジンのベクトルを取得
        Vector2 vel = owner.rigidBody2D.velocity;

        //SpiralStarを回転させる
        owner.rotAngle += new Vector3(0,0,4) * Mathf.Clamp(vel.magnitude,0.0f,7.0f);

        //ベクトルの長さが最小値より大きいとき
        if (vel.magnitude > SpiralStar.MIN_MOVE_LIMIT)
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

        //Debug.Log(owner.rigidBody2D.velocity.magnitude * 10);
    }

    /// <summary>
    /// Stateの開始処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="preState">前回のステート</param>
    public override void OnEnter(SpiralStar owner, StateBase<SpiralStar> preState) 
    {
        //物理エンジンで力を加える
        owner.rigidBody2D.AddForce(m_dir * m_scalar, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Stateが終了処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="nextState">次のState</param>
    public override void OnExit(SpiralStar owner, StateBase<SpiralStar> nextState) { }

    /// <summary>
    /// 方向を示すベクトル
    /// セッター　ゲッター
    /// </summary>
    public Vector3 Direct
    {
        get { return m_dir; }
        set { m_dir = value; }
    }

    /// <summary>
    /// ベクトルの倍率
    /// セッター、ゲッター
    /// </summary>
    public float Scalar 
    {
        get { return m_scalar; }
        set { m_scalar = value; }
    }
}
