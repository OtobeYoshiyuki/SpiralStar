using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    //オブジェクトの回転値
    protected Vector3 m_rotAngle = Vector3.zero;

    //オブジェクトを移動させるスピード
    protected Vector3 m_moveSpeed = Vector3.zero;

    //オブジェクトをスケーリングさせるスピード
    protected Vector3 m_scaleSpeed = Vector3.zero;

    /// <summary>
    /// RigidBody2DのComponent
    /// </summary>
    protected Rigidbody2D m_rigidBody2D = null;

    /// <summary>
    /// CirCleのCollider
    /// 当たり判定
    /// </summary>
    protected CircleCollider2D m_circleCollider2D = null;

    /// <summary>
    /// 物理エンジンから力を加える最小値
    /// </summary>
    public const float MIN_MOVE_LIMIT = 0.03f;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    protected Movement()
    {

    }

   //移動処理
   public void Move()
    {
        //オブジェクトを移動させる
        transform.position += m_moveSpeed;
    }

    //回転処理
    public void Rotation()
    {
        //オブジェクトを指定した値に回転させる
        transform.rotation = Quaternion.Euler(m_rotAngle);
    }

    //拡大縮小
    public void Scaling()
    {

    }

    /// <summary>
    /// 回転の値
    /// ゲッター、セッター
    /// </summary>
    public Vector3 rotAngle
    {
        get { return m_rotAngle; }
        set { m_rotAngle = value; }
    }

    /// <summary>
    /// 1フレームに移動させる値
    /// ゲッター、セッター
    /// </summary>
    public Vector3 moveSpeed
    {
        get { return m_moveSpeed; }
        set { m_moveSpeed = value; }
    }

    /// <summary>
    /// RigidBody2Dを取得する
    /// ゲッター
    /// </summary>
    public Rigidbody2D rigidBody2D
    {
        get { return m_rigidBody2D; }
    }

    /// <summary>
    /// CircleCollider2D
    /// ゲッター
    /// </summary>
    public CircleCollider2D circle2D
    {
        get { return m_circleCollider2D; }
    }
}
