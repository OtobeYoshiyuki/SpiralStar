using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    /// 敵の情報
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private List<EnemyStarData> m_enemyDatas = null;

    /// <summary>
    /// やられた敵のIDを保有する配列
    /// </summary>
    private List<int> m_beKill_Ids = null;

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
        //やられた敵のIDを保有するListを作成
        m_beKill_Ids = new List<int>();

        for(int i = 0; i < MAX_NUM;i++)
        {
            //生成のための情報を一時的に追加する
            m_beKill_Ids.Add(i);
        }
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
    /// <param name="num">生成する数</param>
    public void CreateBlackStar(in int kinds)
    {
        //StarManagerを取得する
        StarManager starManager = StarManager.Instance;

        //敵の情報を取得する(先頭から順に取得する)
        EnemyStarData enemyStarData = m_enemyDatas[m_beKill_Ids[0]];

        //敵GameObjectを生成
        GameObject enemyStar = Instantiate(m_starPrefab, enemyStarData.location, Quaternion.identity);

        //スクリプトを宣言する
        BlackStar blackStar = enemyStar.GetComponent<BalanStar>();

        //SpriteRendererを取得する
        SpriteRenderer sprite = enemyStar.GetComponent<SpriteRenderer>();

        //識別するIDを登録する
        blackStar.id = kinds;

        //画像の色を設定する
        sprite.color = enemyStarData.color;

        //敵をListに追加
        starManager.GetEmemyList().Add(blackStar);
        starManager.GetStarList().Add(blackStar);

        //敵の情報を削除する
        m_beKill_Ids.RemoveAt(0);
    }

    /// <summary>
    /// 敵GameObjectを解放
    /// </summary>
    /// <param name="id">識別番号</param>
    public void ReleaseBlackStar(in int id)
    {
        //StarManagerを取得する
        StarManager starManager = StarManager.Instance;

        //指定したIDのオブジェクトの解放
        ReleaseStar(id, starManager.GetEmemyList());

        //指定したIDのオブジェクトの解放
        ReleaseStar(id, starManager.GetStarList());

        //削除したIDを追加する
        m_beKill_Ids.Add(id);
    }

    /// <summary>
    /// 合致するIDを持つGameObjectを削除する
    /// </summary>
    /// <typeparam name="starT">StarBaseを継承した型でなければならない</typeparam>
    /// <param name="id">対象の識別番号</param>
    /// <param name="stars">対象の配列</param>
    public void ReleaseStar<starT>(in int id, List<starT> stars) where starT : StarBase
    {
        for (int i = 0; i < stars.Count; i++)
        {
            //派生クラスのスクリプトを取得する
            StarBase star = stars[i];

            //同じIDのGameObjectが見つかったら
            if (star.id == id)
            {
                //オブジェクトを消去する
                Destroy(star.gameObject);

                //配列の要素を消す
                stars.RemoveAt(i);

                //一度消したら、ほかの処理は飛ばす
                return;
            }
        }
    }
}


