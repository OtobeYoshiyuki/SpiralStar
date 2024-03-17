using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : Singleton<StarManager>
{
    /// <summary>
    /// Playerが操作するGameObject
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    GameObject m_playerObject = null;

    /// <summary>
    /// Playerのインスタンス
    /// </summary>
    private SpiralStar m_spralStar = null;

    /// <summary>
    /// 敵enemyのリスト
    /// </summary>
    private List<BlackStar> m_enemyStars = new List<BlackStar>();

    /// <summary>
    /// すべてのStarのリスト
    /// </summary>
    private List<StarBase> m_allStars = new List<StarBase>();

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
        //スクリプトを登録する
        m_spralStar = m_playerObject.GetComponent<SpiralStar>();

        //配列に追加する
        m_allStars.Add(m_spralStar);
    }

    /// <summary>
    /// 廃棄処理
    /// </summary>
    protected override void Release()
    {
    }

    /// <summary>
    /// Playerが操作しているStar
    /// ゲッター　セッター
    /// </summary>
    public SpiralStar playerStar 
    { 
        get { return m_spralStar; }
        set { m_spralStar = value; }
    }

    /// <summary>
    /// enemyStarのList
    /// ゲッター
    /// </summary>
    public List<BlackStar> GetEmemyList()  { return m_enemyStars; } 

    /// <summary>
    /// StarのList
    /// ゲッター
    /// </summary>
    public List<StarBase> GetStarList()  { return m_allStars; } 

    /// <summary>
    /// 指定したインデックスのEnemyStarを取得する
    /// </summary>
    /// <param name="index">インデックス</param>
    /// <returns>EnemyStar</returns>
    public BlackStar GetBlackStar(int index) { return m_enemyStars[index]; }

    /// <summary>
    /// 指定したインデックスのStarを取得する
    /// </summary>
    /// <param name="index">インデックス</param>
    /// <returns>StarBase</returns>
    public StarBase GetStar(int index) { return m_allStars[index]; }
}
