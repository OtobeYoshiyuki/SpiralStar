using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlackStarの基底クラス
/// </summary>
public abstract class BlackStar : StarBase
{
    /// <summary>
    /// 有限StateMachine
    /// </summary>
    protected StateMachine<BlackStar> m_stateMachine = null;

    /// <summary>
    /// BlackStarの回転のState
    /// </summary>
    protected BlackRotation m_rotateState = null;

    /// <summary>
    /// BlackStarの移動のState
    /// </summary>
    protected BlackMove m_moveState = null;

    /// <summary>
    /// BlackStarの衝突時のState
    /// </summary>
    protected BlackCollision m_collisionState = null;

    /// <summary>
    /// Playerの操作するStarにアクセスするためのクラス
    /// </summary>
    private SpiralStar m_playerStar = null;

    /// <summary>
    /// キャラを識別するためのID
    /// </summary>
    private int m_id = 0;

    /// <summary>
    /// GameObjectに設定されているタグ
    /// </summary>
    public const string BLACKSTAR_TAG = "BlackStar";

    //攻撃を受けたときのレイヤー
    public const int COLLISION_LAYER = 7;

    //コンストラクタ
    protected BlackStar() : base()
    {

    }

    /// <summary>
    /// 星の共通の処理を呼ぶ
    /// </summary>
    //初期化
    public override void StarInit()
    {
        //基底クラスの処理を呼ぶ
        base.StarInit();
    }

    //更新処理
    public override void StarUpdate()
    {
        //基底クラスの処理を呼ぶ
        base.StarUpdate();

        //死亡したとき
        if(deth)
        {
            //ステートを変更する
            m_stateMachine.ChangeState(blackCollision);

            //レイヤーを変更する
            gameObject.layer = COLLISION_LAYER;

            //フラグを落とす
            deth = false;
        }
    }

    //終了処理
    public override void StarFinal()
    {
        //基底クラスの処理を呼ぶ
        base.StarFinal();
    }

    /// <summary>
    /// StateMachine
    /// ゲッター　
    /// </summary>
    public StateMachine<BlackStar> stateMachine
    {
        get { return m_stateMachine; }
    }

    /// <summary>
    /// BlackStarの回転用のState
    /// ゲッター
    /// </summary>
    public BlackRotation blackRotation
    {
        get { return m_rotateState; }
    }

    /// <summary>
    /// BlackStarの移動用のState
    /// ゲッター
    /// </summary>
    public BlackMove blackMove
    {
        get { return m_moveState; }
    }

    /// <summary>
    /// BlackStarの衝突用のState
    /// ゲッター
    /// </summary>
    public BlackCollision blackCollision
    {
        get { return m_collisionState; }
    }

    /// <summary>
    /// SpiralStar（Playerが操作している）
    /// ゲッター　セッター
    /// </summary>
    public SpiralStar starPlayer
    {
        get { return m_playerStar; }
        set { m_playerStar = value; }
    }

    /// <summary>
    /// id（識別番号）
    /// ゲッター　セッター
    /// </summary>
    public int id
    {
        get { return m_id; }
        set { m_id = value; }
    }
}
