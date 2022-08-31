using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SpiralStarが回転するState
/// StateBaseを継承
/// テンプレートの方は、インスタンスの所有者のSpiralStarを指定
/// </summary>
public class SpiralRotation : StateBase<SpiralStar>
{
    /// <summary>
    /// 矢印を生成するフラグ
    /// </summary>
    private bool m_fArrowCreate = false;

    /// <summary>
    /// オブジェクトの回転させる速度
    /// 定数　ゲッター
    /// </summary>
    public static Vector3 ROTSPEED { get { return new Vector3(0.0f, 0.0f, 15.0f); } }

    /// <summary>
    /// 生成する矢印の相対座標
    /// </summary>
    public static Vector3 RELATIVEARROW { get { return new Vector3(0.0f, 0.25f, 0.0f); } }

    /// <summary>
    /// 180~360度の補正値を取得
    /// 定数
    /// </summary>
    public const float MINUSANGLE = 180.0f;

    /// <summary>
    /// 矢印の座標の修正
    /// 定数
    /// </summary>
    public const float CALCARROW_LOCATION = 0.25f;

    /// <summary>
    /// 半周の角度
    /// 定数
    /// </summary>
    public const float RIGHT_ANGLE = 90.0f;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public SpiralRotation() { }

    /// <summary>
    /// Stateの実行処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    public override void OnExecute(SpiralStar owner) 
    {
        //GamePadの左スティックの入力を取得する
        Vector2 move = owner.actions.Player.Move.ReadValue<Vector2>();

        //物理エンジンのベクトルを取得
        Vector2 vel = owner.rigidBody2D.velocity;

        //ベクトルの長さが最小値より大きいとき
        if (vel.magnitude > Movement.MIN_MOVE_LIMIT)
        {
            //ベクトルを正規化
            vel.Normalize();

            //ベクトルを反転
            vel *= -1;

            //物理エンジンで力を加える
            owner.rigidBody2D.AddForce(vel * 3, ForceMode2D.Force);
        }
        //ベクトルの長さが最小値以下の時
        else
        {
            //ベクトルをゼロにする
            owner.rigidBody2D.velocity = Vector2.zero;
        }

        //GamePadのAボタンが押されたかどうか
        if (owner.actions.Player.Atack.IsPressed())
        {
            //SpiralStarを回転させる
            owner.rotAngle += ROTSPEED;

            //ゲージのチャージを行う
            StarChaegeUI.Instance.OnCharge();

            //矢印のインスタンスを生成する
            OnArrowInstantiate(owner);
        }

        //GamePadのAボタンが離された時
        if(owner.actions.Player.Atack.WasReleasedThisFrame())
        {
            //チャージUIから画像を取得
            Image image = StarChaegeUI.Instance.image;

            //チャージのAnimationCurveをベクトルの倍率に設定
            owner.spiralMove.Scalar = owner.curve.Evaluate(image.fillAmount);

            //キーの入力状態によって移動方向を変える
            owner.spiralMove.Direct = move == Vector2.zero ? Vector2.up : move;

            //ゲージの初期化を行う
            StarChaegeUI.Instance.OnReset();

            //Stateを切り替える
            owner.stateMachine.ChangeState(owner.spiralMove);

            //以後の処理は飛ばす
            return;
        }

        //左スティックの入力があったとき
        if (owner.actions.Player.Move.IsPressed())
        {
            //矢印のインスタンスを生成する
            OnArrowInstantiate(owner);

            //矢印が生成されている場合
            if (owner.arrow)
            {
                //矢印の回転角度を求める
                float radian = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;

                //矢印の座標を再設定する
                owner.arrow.transform.position = new Vector3(move.x * 0.25f, move.y * 0.25f,0.0f) + 
                    new Vector3(owner.rigidBody2D.position.x, owner.rigidBody2D.position.y,0.0f);
                
                //角度を再設定する
                owner.arrow.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -radian));
            }
        }

        //左スティックが離されたとき
        if (owner.actions.Player.Move.WasReleasedThisFrame())
        {
            //矢印のインスタンスを削除する
            OnArrowRelease(owner);
        }
    }

    /// <summary>
    /// Stateの開始処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="preState">前回のステート</param>
    public override void OnEnter(SpiralStar owner, StateBase<SpiralStar> preState) 
    {
        //矢印の生成のフラグを切る
        m_fArrowCreate = false;
    }

    /// <summary>
    /// Stateが終了処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="nextState">次のState</param>
    public override void OnExit(SpiralStar owner, StateBase<SpiralStar> nextState) 
    {
        //矢印のインスタンスを削除する
        OnArrowRelease(owner);
    }

    /// <summary>
    /// 矢印のインスタンスを生成する
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    public void OnArrowInstantiate(SpiralStar owner)
    {
        //生成フラグがfalseのとき
        if (!m_fArrowCreate)
        {
            //矢印のインスタンスを生成する
            ArrowFactory.Instance.CreateArrow(owner, RELATIVEARROW);

            //フラグを起こす
            m_fArrowCreate = true;
        }
    }

    /// <summary>
    /// 矢印のインスタンスを削除する
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    public void OnArrowRelease(SpiralStar owner)
    {
        //生成フラグがtrueのとき
        if (m_fArrowCreate)
        {
            //矢印のインスタンスを削除する
            ArrowFactory.Instance.ReleaseArrow(owner);

            //フラグを切る
            m_fArrowCreate = false;
        }
    }
}
