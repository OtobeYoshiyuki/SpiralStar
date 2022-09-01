using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMeshFactory : Singleton<EffectFactory>
{
    /// <summary>
    /// スコアのメッシュオブジェクト
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private GameObject m_socoreMesh = null;

    /// <summary>
    /// SpiralStarとScoreMeshとの相対距離
    /// Inspecterから編集できるようにする
    /// </summary>
    [SerializeField]
    private Vector3 m_relative = Vector3.zero;

    /// <summary>
    /// prefabのTextMeshProのコンポーネント
    /// </summary>
    private TextMeshPro m_meshProCm = null;

    /// <summary>
    /// 生成するメッシュオブジェクト
    /// </summary>
    private GameObject m_effectScoreMesh = null;

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
        //アタッチされているコンポーネントを取得する
        m_meshProCm = m_socoreMesh.GetComponent<TextMeshPro>();
    }

    /// <summary>
    /// GameObjectの解放処理
    /// </summary>
    protected override void Release()
    {
    }

    /// <summary>
    /// スコアメッシュが表示中かどうか
    /// </summary>
    /// <returns>表示中はtrue 非表示の時はfalse</returns>
    public bool ScoreMeshEnable()
    {
        //インスタンスが生成されているときはtrueを返す
        //インスタンスが生成されていないときはfalseを返す
        return m_effectScoreMesh != null ? true : false;
    }

    /// <summary>
    /// prefabから新しいScoreMeshを作成する
    /// </summary>
    /// <param name="star">SpiralStar</param>
    public void CreateScoreMesh(SpiralStar star)
    {
        
    }
}
