using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    /// <summary>
    /// 倒して得られるスコアの値
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private float m_getScore = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Init()
    {
    }

    /// <summary>
    /// 廃棄処理
    /// </summary>
    protected override void Release()
    {
    }
}
