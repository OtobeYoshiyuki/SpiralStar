using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアの制御クラス
/// </summary>
public class ScoreController
{
    /// <summary>
    /// スコアの計算時間の最大値
    /// 定数
    /// </summary>
    public const float CALCKING_TIME = 1.0f;

    /// <summary>
    /// 計算中かどうかのフラグ
    /// </summary>
    private bool m_isCalcing = false;

    /// <summary>
    /// スコアの計算時間
    /// </summary>
    private float m_scoreTime = 0.0f;

    /// <summary>
    /// 経過時間のタイムスケール
    /// </summary>
    private float m_timeScale = 0.0f;

    /// <summary>
    /// スコアの最大値
    /// </summary>
    private float m_maxScore = 0.0f;

    /// <summary>
    /// スコアの最小値
    /// </summary>
    private float m_minScore = 0.0f;

    /// <summary>
    /// スコアクラス
    /// </summary>
    private Score m_score = new Score();

    /// <summary>
    /// スコアの初期化処理
    /// </summary>
    /// <param name="isCalc">計算中のフラグ</param>
    /// <param name="time">計算時間</param>
    /// <param name="scale">タイムスケール</param>
    /// <param name="max">スコアの最大値</param>
    /// <param name="min">スコアの最小値</param>
    /// <param name="now">現在のスコア</param>
    /// <param name="before">計算前のスコア</param>
    /// <param name="after">計算後のスコア</param>
    public void InitScore(bool isCalc,float time,float scale,float max,float min,float now,float before,float after)
    {
        //計算中のフラグを設定する
        m_isCalcing = isCalc;

        //計算時間を設定する
        m_scoreTime = time;

        //タイムスケールを設定する
        m_timeScale = scale;

        //スコアの最大値を設定する
        m_maxScore = max;

        //スコアの最小値を設定する
        m_minScore = min;

        //スコアクラスの初期化処理
        m_score.InitScore(now, before, after);
    }

    /// <summary>
    /// スコアの更新処理
    /// </summary>
    public void UpdateScore()
    {
        //計算中ではないときは、何もしない
        if (!m_isCalcing) return;

        //スコアの更新をかけて、計算中かどうかをチェックする
        bool check = m_score.UpdateScore(this);

        //スコアが計算中の場合
        if(check)
        {
            //経過時間を更新する
            m_scoreTime += Time.deltaTime * m_timeScale;
        }
        //スコアの計算が完了した場合
        else
        {
            //経過時間の初期化
            m_scoreTime = 0.0f;

            //計算中のフラグを落とす
            m_isCalcing = false;
        }
    }

    /// <summary>
    /// スコアの計算をする処理
    /// </summary>
    /// <param name="score">スコアの値</param>
    /// <param name="timeScale">タイムスケール</param>
    public void OnCaclScore(float score,float timeScale)
    {
        //計算用のフラグを起こす
        m_isCalcing = true;

        //経過時間を初期化する
        m_scoreTime = 0.0f;

        //タイムスケールを変更する
        m_timeScale = timeScale;

        //計算前のスコアを現在のスコアに設定する
        m_score.before = m_score.now;

        //計算後のスコアを現在のスコアから引数のスコアを値を足したものにする
        m_score.after = m_score.now + score;
    }

    /// <summary>
    /// 計算中のフラグ
    /// ゲッター　セッター
    /// </summary>
    public bool isCacl
    {
        set { m_isCalcing = value; }
        get { return m_isCalcing; }
    }

    /// <summary>
    /// スコアの経過時間
    /// ゲッター　セッター
    /// </summary>
    public float scoreTime
    {
        set { m_scoreTime = value; }
        get { return m_scoreTime; }
    }

    /// <summary>
    /// 経過時間のタイムスケール
    /// ゲッター　セッター
    /// </summary>
    public float timeScale
    {
        set { m_timeScale = value; }
        get { return m_timeScale; }
    }

    /// <summary>
    /// スコアの最大値
    /// ゲッター　セッター
    /// </summary>
    public float maxScore
    {
        set { m_maxScore = value; }
        get { return m_maxScore; }
    }

    /// <summary>
    /// スコアの最小値
    /// ゲッター　セッター
    /// </summary>
    public float minScore
    {
        set { m_minScore = value; }
        get { return m_minScore; }
    }

    /// <summary>
    /// スコアクラス
    /// ゲッター
    /// </summary>
    public Score score { get { return m_score; } }
}
