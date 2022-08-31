using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlackStarを生成する工場
/// </summary>
public class BlackStarFactory : Singleton<BlackStarFactory>
{
    /// <summary>
    /// 敵のBaseとなるプレハブ
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private GameObject m_starPrefab = null;

    /// <summary>
    /// 生成する座標を指定する
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private List<Vector3> m_spawnLocations = null;

    /// <summary>
    /// 画像の色を指定する
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private List<Color> m_spriteColors = null;

    /// <summary>
    /// 敵のインスタンス
    /// </summary>
    private List<GameObject> m_enemyStars = null;

    /// <summary>
    /// 敵の数
    /// 定数
    /// </summary>
    public const int MAX_NUM = 1; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// インスタンスの初期化処理
    /// </summary>
    protected override void Init()
    {
        //GameObjectのインスタンスを保持留守ためのListを生成
        m_enemyStars = new List<GameObject>();
    }

    /// <summary>
    /// GameObjectの解放処理
    /// </summary>
    protected override void Release()
    {
        //ReleaseBlackStar(0);
    }

    /// <summary>
    /// 敵GameObjectを生成
    /// </summary>
    /// <param name="star">PlayerのStar</param>
    /// <param name="num">生成する数</param>
    public void CreateBlackStar(SpiralStar star,in int kinds)
    {
        //敵GameObjectを生成
        GameObject enemyStar = Instantiate(m_starPrefab, m_spawnLocations[kinds], Quaternion.identity);

        //基底クラスにPlayerクラスのインスタンスを登録
        enemyStar.GetComponent<BalanStar>().starPlayer = star;

        //識別するIDを登録する
        enemyStar.GetComponent<BalanStar>().id = kinds;

        //画像の色を設定する
        enemyStar.GetComponent<SpriteRenderer>().color = m_spriteColors[kinds];

        //敵をListに追加
        m_enemyStars.Add(enemyStar);

    }

    /// <summary>
    /// 敵GameObjectを解放
    /// </summary>
    /// <param name="id">識別番号</param>
    public void ReleaseBlackStar(in int id)
    {
        for (int i = 0;i < m_enemyStars.Count;i++)
        {
            //派生クラスのスクリプトを取得する
            BalanStar balanStar = m_enemyStars[i].GetComponent<BalanStar>();

            //同じIDのGameObjectが見つかったら
            if(balanStar.id == id)
            {
                //オブジェクトを消去する
                Destroy(m_enemyStars[i]);

                //配列の要素を消す
                m_enemyStars.RemoveAt(i);

                //一度消したら、ほかの処理は飛ばす
                return;
            }
        }
    }
}
