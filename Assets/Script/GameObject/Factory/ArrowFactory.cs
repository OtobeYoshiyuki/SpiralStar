using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Arrowを生成する工場
/// </summary>
public class ArrowFactory : Singleton<ArrowFactory>
{
    /// <summary>
    /// 矢印のPrefabのGameObject
    /// </summary>
    [SerializeField]
    private GameObject m_arrowPrefab = null;

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
    }

    /// <summary>
    /// GameObjectの解放処理
    /// </summary>
    protected override void Release()
    {

    }

    /// <summary>
    /// ArrowのGameObjectを生成する
    /// </summary>
    /// <param name="star">Arrowの親オブジェクト</param>
    /// <param name="relative">Arrowに親子付けした際の相対座標</param>
    public void CreateArrow(SpiralStar star,in Vector3 relative) 
    {
        //矢印のGameObjectのワールド座標を設定する
        Vector3 worldPos = new Vector3(star.rigidBody2D.position.x,star.rigidBody2D.position.y,0.0f) + relative;

        //プレハブのインスタンスを生成
        star.arrow = Instantiate(m_arrowPrefab, worldPos, Quaternion.identity);
    }

    /// <summary>
    /// 矢印のGameObjectを削除する
    /// </summary>
    /// <param name="star">矢印の親オブジェクト</param>
    public void ReleaseArrow(SpiralStar star)
    {
        //矢印のGameObjectを削除する
        Destroy(star.arrow);

        //矢印を初期化する
        star.arrow = null;
    }
}
