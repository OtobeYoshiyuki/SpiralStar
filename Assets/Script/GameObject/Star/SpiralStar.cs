using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーが操作するスパイラルスター
/// </summary>
public class SpiralStar : StarBase
{
    /// <summary>
    /// キー入力を管理するクラス
    /// </summary>
    private MyAction m_myAction = null;

    /// <summary>
    /// 矢印のGameObject
    /// SpiralStarの進行方向を指す
    /// </summary>
    private GameObject m_childArrow = null;

    /// <summary>
    /// 有限StateMachine
    /// </summary>
    private StateMachine<SpiralStar> m_stateMachine = null;

    /// <summary>
    /// SpiralRotationのState
    /// </summary>
    private SpiralRotation m_spiralRotation = null;

    /// <summary>
    /// SpiralMoveのState
    /// </summary>
    private SpiralMove m_spiralMove = null;

    /// <summary>
    /// SpiralCollisionのState
    /// </summary>
    private SpiralCollision m_spiralCollision = null;

    /// <summary>
    /// 移動量をスカラ倍するアニメーションカーブ
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private AnimationCurve m_chargeCurve = null;

    /// <summary>
    /// GameObjectに設定されているタグ
    /// 定数
    /// </summary>
    public const string SPIRALSTAR_TAG = "Player";

    /// <summary>
    /// Fiverステータスのkey
    /// 定数
    /// </summary>
    public const string FIVER = "Fiver";

    /// <summary>
    /// Boostステータスのkey
    /// 定数
    /// </summary>
    public const string BOOST = "Boost";

    /// <summary>
    /// ダメージの最小限の力
    /// </summary>
    public const float DAMAGE_MIN_POWER = 30.0f;

    [SerializeField]
    private Blink m_blink = new Blink();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public SpiralStar():base()
    {
        //SpiralRotationのインスタンスを生成
        m_spiralRotation = new SpiralRotation();

        //SpiralMoveのインスタンスを生成
        m_spiralMove = new SpiralMove();

        //SpiralCollisionのインスタンスを生成
        m_spiralCollision = new SpiralCollision();
    }

    /// <summary>
    /// インスタンスの生成直後に呼ばれる処理
    /// </summary>
    private void Awake()
    {
        //キー入力の管理クラスを生成
        m_myAction = new MyAction();
    }

    // Start is called before the first frame update
    void Start()
    {
        //IDを設定する
        id = 0;

        //SpriteRendererを取得する
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        //星の初期化処理
        StarInit();

        //有限StateMachineのインスタンスを生成
        m_stateMachine = new StateMachine<SpiralStar>(this, m_spiralRotation);

        for (int i = 1; i <= BlackStarFactory.MAX_NUM; i++)
        {
            //敵のStarのインスタンスを生成
            BlackStarFactory.Instance.CreateBlackStar(i);
        }

        //イベント関数を登録する
        m_blink.drawEnable = () => sprite.color = Color.yellow;
        m_blink.drawDisable = () => sprite.color = Utility.SetColorAddtive(Color.yellow, Color.red,
            (SpriteRenderer renderer, float alfa) => Utility.SetColorOpacity(renderer, alfa), sprite, 0.5f) ;
        m_blink.resetAction = () => sprite.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        //点滅の更新処理
        m_blink.Update();

        //星の更新処理
        StarUpdate();

        //GamePadのAボタンが押されたら
        if (m_myAction.Player.Atack.WasPressedThisFrame())
        {
            //SpiralRotationへと移行する
            m_stateMachine.ChangeState(m_spiralRotation);
        }

        //ダメージを受けたとき
        if (damage)
        {
            //HPゲージにダメージを与える
            HpGageUI.Instance.OnGageDamageAnimation(this);

            //チャージをリセットする
            StarChaegeUI.Instance.OnReset();

            //点滅を初期化する
            m_blink.OnReset();

            //点滅を開始する
            m_blink.blink = true;

            //フラグを落とす
            damage = false;
        }

        //表示する文字を加工する
        StarChaegeUI.Instance.ManufacturingText(this);

        //StateMachineの更新処理
        m_stateMachine.UpdateState();
    }

    /// <summary>
    /// 当たった瞬間を検知する
    /// </summary>
    /// <param name="collision">当たったオブジェクトの情報</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //BlackStarに衝突した場合
        if(collision.gameObject.tag == BlackStar.BLACKSTAR_TAG)
        {
            //StarChargeUIを取得する
            StarChaegeUI starChaegeUI = StarChaegeUI.Instance;

            //StatusManagerを取得する
            StatusManager statusManager = StatusManager.Instance;

           //アタッチされているスクリプトを取得する
            BlackStar blackStar = collision.gameObject.GetComponent<BalanStar>();

            //自身が攻撃中の時(チャージ中の時は起動しない)
            if (m_stateMachine.currentState == m_spiralMove)
            {
                //自身のパワーが規定値以上の場合
                if (starChaegeUI.power >= DAMAGE_MIN_POWER)
                {
                    //敵を倒す
                    blackStar.deth = true;
                }
                //パワーが足りないとき
                else
                {
                    //ダメージを受けていないとき
                    if (!m_blink.blink)
                    {
                        //自分がダメージを受ける
                        damage = true;

                        //ダメージ計算を行う
                       statusManager.OnDamageStatus(statusCs, blackStar.statusCs);
                    }
                }
            }
            else
            {
                //自身がチャージ中の時
                if (m_stateMachine.currentState == m_spiralRotation)
                {
                    //ダメージを受けていないとき
                    if (!m_blink.blink)
                    {
                        //無条件でダメージを受ける
                        damage = true;

                        //ダメージ計算を行う
                        statusManager.OnDamageStatus(statusCs, blackStar.statusCs);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Objectが有効になったときに呼ばれる処理
    /// </summary>
    private void OnEnable()
    {
        //キー入力を有効にする
        m_myAction.Enable();
    }

    /// <summary>
    /// Objectが向こうになったときに呼ばれる処理
    /// </summary>
    private void OnDisable()
    {
        //キー入力を無効にする
        m_myAction.Disable();
    }

    /// <summary>
    /// StateMachineを取得
    /// ゲッター
    /// </summary>
    public StateMachine<SpiralStar> stateMachine { get { return m_stateMachine; } }

    /// <summary>
    /// SpiralRotationのStateを取得
    /// ゲッター
    /// </summary>
    public SpiralRotation spiralRotation { get { return m_spiralRotation; } }

    /// <summary>
    /// SpiralMoveのStateを取得
    /// ゲッター
    /// </summary>
    public SpiralMove spiralMove { get { return m_spiralMove; } }

    /// <summary>
    /// SpiralCollisionのStateを取得
    /// ゲッター
    /// </summary>
    public SpiralCollision spiralCollision { get { return m_spiralCollision; } }

    /// <summary>
    /// 矢印のGameObject
    /// ゲッター、セッター
    /// </summary>
    public GameObject arrow { get { return m_childArrow; } set { m_childArrow = value; } }

    /// <summary>
    /// キー入力を取得
    /// ゲッター
    /// </summary>
    public MyAction actions { get { return m_myAction; } }

    /// <summary>
    /// チャージのAnimationCurveを取得
    /// ゲッター
    /// </summary>
    public AnimationCurve curve { get { return m_chargeCurve; } }

    /// <summary>
    /// 点滅の状態を取得
    /// ゲッター
    /// </summary>
    public Blink blink { get { return m_blink; } }

}
