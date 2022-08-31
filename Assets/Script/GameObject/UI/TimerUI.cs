using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// StarのチャージするUIを管理するクラス
/// Game中に1つしか存在しないので、Singletonを継承
/// </summary>
public class TimerUI : Singleton<TimerUI>
{
    /// <summary>
    /// TextComponentを持つGameObject
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private GameObject m_textObject = null;

    /// <summary>
    /// 60~0秒を表すGameObject
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private GameObject m_timerNormalObject = null;

    /// <summary>
    /// 120~60秒を表すGameObject
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private GameObject m_timerOverObject = null;

    /// <summary>
    /// TextObjectのTextComponentを格納する変数
    /// </summary>
    private Text m_timerTextUI = null;

    /// <summary>
    /// 現在の時間を表す変数
    /// </summary>
    private float m_time = 0.0f;

    /// <summary>
    /// 時間の限界地を表す変数（60~120）
    /// </summary>
    private float m_limitTime = 0.0f;

    /// <summary>
    /// 開始する時間
    /// 定数
    /// </summary>
    public const float START_TIME = 60.0f;

    /// <summary>
    /// 時間の限界値の最大を表す
    /// 定数
    /// </summary>
    public const float MAX_LIMIT_TIME = 120.0f;

    /// <summary>
    /// 最大の桁数
    /// 定数
    /// </summary>
    public const int MAX_NUMBER = 3;

    /// <summary>
    /// タイマーの終了を検知するフラグ
    /// </summary>
    private bool m_finishTimer = false;

    /// <summary>
    /// タイマーを更新するフラグ
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private bool m_updateTimer = false;

    // Update is called once per frame
    void Update()
    {
        //ImageComponentの初期化
        Image timerImage = null;

        //比率を求める変数の初期化
        float ratio = 0.0f;

        //終了フラグがオンの時、以降の処理は飛ばす
        if (m_finishTimer) return;

        //現在の時間が61~120秒の間の時
        if (m_time <= MAX_LIMIT_TIME && m_time > START_TIME)
        {
            //ImageComponentを取得する
            timerImage = m_timerOverObject.GetComponent<Image>();

            //時間の比率を取得する
            ratio = m_time / MAX_LIMIT_TIME;
        }
        //現在の時間が0~60秒の間の時
        else
        {
            //ImageComponentを取得する
            timerImage = m_timerNormalObject.GetComponent<Image>();

            //時間の比率を取得する
            ratio = m_time / START_TIME;
        }

        //時間を更新する
        m_time -= Time.deltaTime;

        //制限時間が切れたら
        if (m_time < 0.0f)
        {
            //時間をゼロにする
            m_time = 0.0f;

            //終了フラグを起こす
            m_finishTimer = true;

        }
        //タイマーのUIを更新する
        timerImage.fillAmount = ratio;

        //現在の時間を更新する
        m_timerTextUI.text = Utility.ValueCustomFrontString(m_time, "f0", MAX_NUMBER, "0");
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Init() 
    {
        //TextComponentを取得
        m_timerTextUI = m_textObject.GetComponent<Text>();

        //時間を初期化する
        m_time = START_TIME;
        m_limitTime = START_TIME;

        //初期フラグを設定する
        m_finishTimer = false;
    }

    /// <summary>
    /// 廃棄処理
    /// </summary>
    protected override void Release() 
    { 
    }

}
