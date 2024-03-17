using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStarData
{
    /// <summary>
    /// 生成する座標を指定する
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private Vector3 m_spawnLocation = Vector3.zero;

    /// <summary>
    /// 画像の色を指定する
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private Color m_spriteColor = Color.white;

    /// <summary>
    /// Spawnする座標
    /// ゲッター
    /// </summary>
    public Vector3 location { get { return m_spawnLocation; } }

    /// <summary>
    /// Spriteの色
    /// ゲッター
    /// </summary>
    public Color color { get { return m_spriteColor; } }

}
