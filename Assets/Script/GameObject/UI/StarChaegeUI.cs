using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// StarのチャージするUIを管理するクラス
/// Game中に1つしか存在しないので、Singletonを継承
/// </summary>
public class StarChaegeUI : Singleton<StarChaegeUI>
{
    /// <summary>
    /// チャージの対象となるGameObject
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private GameObject m_skyChaegeStar = null;

    /// <summary>
    /// TextのCompomentを持つGameObject
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private GameObject m_speedTextObject = null;

    /// <summary>
    /// UIObjectのImageCompomentを格納する変数
    /// </summary>
    private Image m_chargeUI = null;

    /// <summary>
    /// TextObjectのTextComponentを格納する変数
    /// </summary>
    private Text m_speedTextUI = null;

    /// <summary>
    /// チャージの最大値
    /// 定数
    /// </summary>
    public const float MAXCHARGE = 1.0f;

    /// <summary>
    /// チャージの初期値
    /// 定数
    /// </summary>
    public const float INITCHARGE = 0.0f;

    /// <summary>
    /// 最大の桁数
    /// 定数
    /// </summary>
    public const int MAX_NUMBER = 3;

    /// <summary>
    /// UIに表示されている最小値の速度
    /// </summary>
    public const float MIN_SPEED = 3.0f;

    /// <summary>
    /// 1フレームごとのUIに表示されている力
    /// </summary>
    private float m_power = 0.0f;

    /// <summary>
    /// チャージしているときに呼ばれる
    /// </summary>
    public void OnCharge()
    {
        //ゲージの比率が最大値未満の時
        if(m_chargeUI.fillAmount < MAXCHARGE)
        {
            //ゲージの比率を加算する
            m_chargeUI.fillAmount += Time.deltaTime;
        }
    }

    /// <summary>
    /// チャージ中にAボタンが離されたら
    /// 呼ばれる
    /// </summary>
    public void OnReset()
    {
        //ゲージを初期化する
        m_chargeUI.fillAmount = INITCHARGE;
    }

    /// <summary>
    /// テキストを表示用に加工する処理
    /// </summary>
    /// <param name="star">インスタンスの所有者</param>
    public void ManufacturingText(SpiralStar star)
    {
        //現在のベクトルを取得（物理エンジンから）
        Vector2 vel = star.rigidBody2D.velocity;

        //ベクトルの長さを取得
        m_power = vel.magnitude * 10;

        //速度が一定以下のものは表示を強制的に0にする
        m_speedTextUI.text = m_power > MIN_SPEED ? Utility.ValueCustomFrontString(m_power, "f0", MAX_NUMBER, "0") : "000";
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Init()
    {
        //ImageComponentを取得
        m_chargeUI = m_skyChaegeStar.GetComponent<Image>();

        //TextComponentを取得
        m_speedTextUI = m_speedTextObject.GetComponent<Text>();
    }

    /// <summary>
    /// 廃棄処理
    /// </summary>
    protected override void Release()
    {
    }


    /// <summary>
    /// ImageComponentを取得
    /// ゲッター
    /// </summary>
    public Image image { get { return m_chargeUI; } }

    /// <summary>
    /// TextComponentを取得
    /// ゲッター
    /// </summary>
    public Text cText { get { return m_speedTextUI; } }

    /// <summary>
    /// Playerの力を取得する
    /// </summary>
    public float power { get { return m_power; } }
}
