using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFactory : Singleton<EffectFactory>
{
    [SerializeField]
    private ParticleSystem m_starEffect = null;

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
    /// 衝突時のエフェクトの生成
    /// </summary>
    /// <param name="star">Starのインスタンス</param>
    [System.Obsolete]
    public void SpawnStarEffect(StarBase star)
    {
        //SpriteRendererを取得する
        SpriteRenderer sprite = star.GetComponent<SpriteRenderer>();

        //effectのGameObjectを生成
        ParticleSystem starEffect = Instantiate(m_starEffect,star.transform.position,Quaternion.identity);

        //effectの色を変更する
        starEffect.startColor = sprite.color;

        //エフェクトを再生する
        starEffect.Play();
    }
}
