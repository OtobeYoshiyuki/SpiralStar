using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアクラス
/// </summary>
public class Score
{
    /// <summary>
    /// 現在のスコア
    /// </summary>
    private float m_nowScore = 0.0f;

    /// <summary>
    /// 計算前のスコア
    /// </summary>
    private float m_beforeScore = 0.0f;

    /// <summary>
    /// 計算後のスコア
    /// </summary>
    private float m_afterScore = 0.0f;

    /// <summary>
    /// スコアの初期化処理
    /// </summary>
    /// <param name="now">現在のスコア</param>
    /// <param name="before">計算前のスコア</param>
    /// <param name="after">計算後のスコア</param>
    public void InitScore(float now,float before,float after)
    {
        //現在のスコアを設定する
        m_nowScore = now;

        //計算前のスコアを設定する
        m_beforeScore = before;

        //計算後のスコアを設定する
        m_afterScore = after;
    }

    /// <summary>
    /// スコアの更新処理
    /// </summary>
    /// <param name="ownew">所有者</param>
    /// <returns>計算中の時はtrue 計算が終わったときはfalse</returns>
    public bool UpdateScore(ScoreController ownew)
    {
        //m_nowScore = Mathf.Clamp()

        //計算中なのでtrueを返す
        return true;
    }

    /// <summary>
    /// 現在のスコア
    /// ゲッター　セッター
    /// </summary>
    public float now
    {
        set { m_nowScore = value; }
        get { return m_nowScore; }
    }

    /// <summary>
    /// 計算前のスコア
    /// ゲッター　セッター
    /// </summary>
    public float before
    {
        set { m_beforeScore = value; }
        get { return m_beforeScore; }
    }

    /// <summary>
    /// 計算後のスコア
    /// ゲッター　セッター
    /// </summary>
    public float after
    {
        set { m_afterScore = value; }
        get { return m_afterScore; }
    }
}
