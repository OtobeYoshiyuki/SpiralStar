using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 星のインターフェース
/// </summary>
public interface IStarBase
{
    //初期化
    public void StarInit();

    //更新処理
    public void StarUpdate();

    //終了処理
    public void StarFinal();
}


/// <summary>
/// 星の基底クラス
/// </summary>
public abstract class StarBase : Movement, IStarBase
{
    /// <summary>
    /// HPステータスのkey
    /// 定数
    /// </summary>
    public const string HP = "Hp";

    /// <summary>
    /// Atackステータスのkey
    /// 定数
    /// </summary>
    public const string ATACK = "Atack";

    /// <summary>
    /// Defenceステータスのkey
    /// 定数
    /// </summary>
    public const string DEFENCE = "Defence";

    /// <summary>
    /// スコアの最大値
    /// 定数
    /// </summary>
    public const float MAX_SCORE = 99999999;

    /// <summary>
    /// スコアの最小値
    /// 定数
    /// </summary>
    public const float MIN_SCORE = 0;

    /// <summary>
    /// Stateの時間を計測する時間
    /// </summary>
    private float m_time = 0.0f;

    /// <summary>
    /// Starの衝突をチェックするフラグ
    /// </summary>
    private bool m_damageCheck = false;

    /// <summary>
    /// キャラがやられたかをチェックするフラグ
    /// </summary>
    private bool m_dethCheck = false;

    /// <summary>
    /// キャラを識別するためのID
    /// </summary>
    private int m_id = 0;

    /// <summary>
    /// ステータスのコントローラー
    /// </summary>
    private StatusController m_statusCs = new StatusController();

    /// <summary>
    /// スコアのコントローラ
    /// </summary>
    private ScoreController m_scoreCs = new ScoreController();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    protected StarBase() : base()
    {

    }

    //初期化
    public virtual void StarInit()
    {
        //RigidBody2Dを取得する
        m_rigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        //CircleCollider2Dを取得する
        m_circleCollider2D = gameObject.GetComponent<CircleCollider2D>();

        //StatusManagerを取得する
        StatusManager statusManager = StatusManager.Instance;

        //自身のステータスの情報を取得する
        List<StatusInfo> infos = statusManager.GetStatusInfoArray(gameObject.tag);

        //ステータスをコントローラーに渡す
        m_statusCs.AddStatuses(infos);

        //スコアの初期化
        m_scoreCs.InitScore(false, 0.0f, 1.0f, MAX_SCORE, MIN_SCORE, 0.0f, 0.0f, 0.0f);
    }

    //更新処理
    public virtual void StarUpdate()
    {
        //移動処理
        Move();

        //回転処理
        Rotation();

        //拡大縮小処理
        Scaling();
    }

    //終了処理
    public virtual void StarFinal()
    {

    }

    /// <summary>
    /// Stateの時間を管理する
    /// ゲッター　セッター
    /// </summary>
    public float time
    {
        get { return m_time; }
        set { m_time = value; }
    }

    /// <summary>
    /// ダメージ用のフラグを管理する
    /// ゲッター　セッター
    /// </summary>
    public bool damage
    {
        get { return m_damageCheck; }
        set { m_damageCheck = value; }
    }

    /// <summary>
    /// 死亡用のフラグを管理する
    /// ゲッター　セッター
    /// </summary>
    public bool deth
    {
        get { return m_dethCheck; }
        set { m_dethCheck = value; }
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

    /// <summary>
    /// ステータスのコントローラーを取得する
    /// ゲッター
    /// </summary>
    public StatusController statusCs { get { return m_statusCs; } }

    /// <summary>
    /// スコアのコントローラーを取得する
    /// ゲッター
    /// </summary>
    public ScoreController scoreCs { get { return m_scoreCs; } }
}