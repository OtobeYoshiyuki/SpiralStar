using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲージの管理クラス
/// </summary>
public class GageManager
{
    /// <summary>
    /// アニメーションが実行中かどうか
    /// </summary>
    private bool m_isAnimation = false;

    /// <summary>
    /// アニメーションの計測時間
    /// </summary>
    private float m_animeTime = 0.0f;

    /// <summary>
    /// タイムスケール
    /// </summary>
    private float m_timeScale = 1.0f;

    /// <summary>
    /// ゲージのアニメーションのリスト
    /// </summary>
    private List<GageAnimation> m_animationList = new List<GageAnimation>();

    /// <summary>
    /// アニメーションの管理クラスの初期化
    /// </summary>
    public void InitGageManager()
    {
        //アニメーションフラグを落とす
        m_isAnimation = false;

        //アニメーションの計測時間を初期化する
        m_animeTime = 0.0f;
    }

    /// <summary>
    /// アニメーションの管理クラスの更新処理
    /// </summary>
    public void UpdateGageManager()
    {
        //アニメーションフラグが落ちているときは何もしない
        if (!m_isAnimation) return;

        //アニメーションの終了をカウントする変数を宣言する
        int animeFinish = 0;

        foreach(GageAnimation animation in m_animationList)
        {
            //アニメーションが終了したか確認する
            bool result = animation.UpdateGage(this);

            //終了していたら、カウントを更新する
            if (result) animeFinish++;

            //アニメーションがすべて終了したら
            if(animeFinish >= m_animationList.Count)
            {
                //フラグとタイマーの更新を行う
                InitGageManager();
            }
            //アニメーションが終わってなければ
            else
            {
                //アニメーション時間の更新を行う
                m_animeTime += Time.deltaTime * m_timeScale;
            }
        }
    }

    /// <summary>
    /// 対象のアニメーションゲージを取得する
    /// </summary>
    /// <param name="index">対象のインデックス</param>
    /// <returns>対象のアニメーションゲージ</returns>
    public GageAnimation GetGageAnimation(int index) { return m_animationList[index]; }

    /// <summary>
    /// 配列にアニメーションを追加する
    /// </summary>
    /// <param name="gage">追加するゲージ</param>
    public void AddGage(GageAnimation gage) { m_animationList.Add(gage); }

    /// <summary>
    /// アニメーションが実行中か確認するフラグ
    /// ゲッター　セッター
    /// </summary>
    public bool isAnimation 
    { 
        get { return m_isAnimation; }
        set { m_isAnimation = value; }
    }

    /// <summary>
    /// アニメーションの計測時間
    /// ゲッター　セッター
    /// </summary>
    public float animeTime 
    { 
        get { return m_animeTime; }
        set { m_animeTime = value; }
    }

    /// <summary>
    /// アニメーションの更新速度のスカラ
    /// ゲッター　セッター
    /// </summary>
    public float timeScale
    {
        get { return m_timeScale; }
        set { m_timeScale = value; }
    }
}
