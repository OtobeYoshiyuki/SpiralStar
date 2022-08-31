using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SpiralStarが衝突したState
/// StateBaseを継承
/// テンプレートの方は、インスタンスの所有者のSpiralStarを指定
/// </summary>
public class SpiralCollision : StateBase<SpiralStar>
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public SpiralCollision() { }

    /// <summary>
    /// Stateの実行処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    public override void OnExecute(SpiralStar owner)
    {
    }

    /// <summary>
    /// Stateの開始処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="preState">前回のステート</param>
    public override void OnEnter(SpiralStar owner, StateBase<SpiralStar> preState)
    {
    }

    /// <summary>
    /// Stateが終了処理
    /// </summary>
    /// <param name="owner">インスタンスの所有者</param>
    /// <param name="nextState">次のState</param>
    public override void OnExit(SpiralStar owner, StateBase<SpiralStar> nextState) { }
}
