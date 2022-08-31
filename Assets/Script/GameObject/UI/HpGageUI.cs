using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HpGageUI : Singleton<HpGageUI>
{
    /// <summary>
    /// HPゲージの初期化の情報
    /// </summary>
    enum HPGAGE_CHILD_INIT : int
    {
        FRONT = 5,//前面のアニメーション
        BACK = 4,//後面のアニメーション
    }

    /// <summary>
    /// 配列の補正後の値
    /// </summary>
    public const int REVERS_ELEMENT = (int)HPGAGE_CHILD_INIT.FRONT;

    /// <summary>
    /// ゲージの管理クラス
    /// </summary>
    private GageManager m_gageManager = new GageManager();

    /// <summary>
    /// アニメーションカーブ
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private AnimationCurve m_damageCurve = null;

    /// <summary>
    /// アニメーションカーブ
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private AnimationCurve m_healCurve = null;

    // Update is called once per frame
    void Update()
    {
        //gageManagerの更新処理
        m_gageManager.UpdateGageManager();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Init()
    {
        //ループで回す値を配列に追加する
        List<HPGAGE_CHILD_INIT> _CHILD_INITs = new List<HPGAGE_CHILD_INIT> { HPGAGE_CHILD_INIT.FRONT, HPGAGE_CHILD_INIT.BACK };

        foreach(HPGAGE_CHILD_INIT _CHILD_INIT in _CHILD_INITs)
        {
            //ゲージのアニメーションを生成する
            GageAnimation animation = new GageAnimation();

            //子供にアタッチされているImageComponentを設定する
            animation.gage = transform.GetChild((int)_CHILD_INIT).gameObject.GetComponent<Image>();

            //GageManagerにアニメーションを追加する
            m_gageManager.AddGage(animation);
        }

    }

    /// <summary>
    /// 廃棄処理
    /// </summary>
    protected override void Release()
    {
    }

    /// <summary>
    /// ゲージのダメージアニメーションを行う
    /// </summary>
    /// <param name="self">自分自身</param>
    public void OnGageDamageAnimation(StarBase self)
    {
        //アニメーションの起動
        m_gageManager.isAnimation = true;
        m_gageManager.animeTime = 0.0f;

        //添え字に変換する
        int front = Utility.AbsCaclInt((int)HPGAGE_CHILD_INIT.FRONT, REVERS_ELEMENT);
        int back = Utility.AbsCaclInt((int)HPGAGE_CHILD_INIT.BACK, REVERS_ELEMENT);

        //ゲージを取得する
        GageAnimation frontGage = m_gageManager.GetGageAnimation(front);
        GageAnimation backGage = m_gageManager.GetGageAnimation(back);

        //処理を登録する
        frontGage.gage.fillAmount = self.statusCs.GetTargetStatus(StarBase.HP) / 
            StatusManager.Instance.dataBase.MaxStatus(StarBase.HP);

        //アニメーションクラス内で実行する関数を登録する
        backGage.imageAction = () =>
        {
            backGage.gage.fillAmount = frontGage.gage.fillAmount + 
            ((backGage.gage.fillAmount - frontGage.gage.fillAmount) *
            m_damageCurve.Evaluate(m_gageManager.animeTime));
            backGage.gage.color = Color.red;
        };
        backGage.resetAction = () =>
        {
            backGage.gage.fillAmount = frontGage.gage.fillAmount;
        };

        //アニメーションの終了時間
        frontGage.finishTime = 0.0f;
        backGage.finishTime = 1.0f;

        //タイムスケールの設定
        m_gageManager.timeScale = 0.5f;
    }
}
