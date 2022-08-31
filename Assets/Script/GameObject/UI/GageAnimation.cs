using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// ゲージのアニメーションクラス
/// </summary>
public class GageAnimation
{
    /// <summary>
    /// 対象のゲージ
    /// </summary>
    private Image m_targetGage = null;

    /// <summary>
    /// アニメーションの終了時間
    /// </summary>
    private float m_animeFinish = 0.0f;

    /// <summary>
    /// 関数オブジェクト
    /// </summary>
    private event Action m_imageAction = null;

    /// <summary>
    /// 関数オブジェクト
    /// </summary>
    private event Action m_resetAction = null;

    /// <summary>
    /// ゲージの更新を行う
    /// </summary>
    /// <param name="manager">ゲージの管理クラス</param>
    /// <returns>制限時間を超えたらfalse 超えていなかったらtrue</returns>
    public bool UpdateGage(GageManager manager)
    {
        //制限時間を超えたら
        if (manager.animeTime > m_animeFinish)
        {
            //リセット用の関数オブジェクトを実行する
            m_resetAction?.Invoke();

            //以降の処理は飛ばす
            return true;
        }

        //設定されている関数オブジェクトを実行する
        m_imageAction?.Invoke();

        //制限時間を越していない
        return false;
    }

    /// <summary>
    /// ゲージのImage
    /// ゲッター　セッター
    /// </summary>
    public Image gage
    {
        set { m_targetGage = value; }
        get { return m_targetGage; }
    }

    /// <summary>
    /// 関数オブジェクト
    /// ゲッター　セッター
    /// </summary>
    public Action imageAction
    {
        get { return m_imageAction; }
        set { m_imageAction = value; }
    }

    /// <summary>
    /// 関数オブジェクト
    /// ゲッター　セッター
    /// </summary>
    public Action resetAction
    {
        get { return m_resetAction; }
        set { m_resetAction = value; }
    }

    /// <summary>
    /// アニメーションの終了時間
    /// ゲッター　セッター
    /// </summary>
    public float finishTime
    {
        set { m_animeFinish = value; }
        get { return m_animeFinish; }
    }
}
