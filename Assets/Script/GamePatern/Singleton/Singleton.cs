using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    /// <summary>
    /// 継承先のインスタンスの変数
    /// </summary>
    private static T s_instance = null;

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static T Instance { get { return s_instance; } }

    /// <summary>
    /// インスタンス化直後に呼ばれる処理
    /// </summary>
    private void Awake()
    {
        //インスタンスがNULLの時
        if(s_instance == null)
        {
            //シングルトンのインスタンスを
            //派生クラスにCastする
            s_instance = this as T;

            //インスタンスを初期化する
            s_instance.Init();

            //Destoryが呼ばれないようにする
            return;
        }

        //インスタンスがすでに生成されているときは、
        //Compormentを削除する
        Destroy(this);
    }

    /// <summary>
    /// MonoBehaviourが廃棄された時に呼ばれる処理
    /// </summary>
    private void OnDestroy()
    {
        //インスタンスがシングルトンの時
        if (s_instance == this)
        {
            //インスタンスをNULLにする
            s_instance = null;
        }

        //派生クラスの解放処理を呼ぶ
        Release();
    }

    /// <summary>
    /// 派生クラスの初期化処理
    /// </summary>
    protected virtual void Init() { }

    /// <summary>
    /// 派生クラスの廃棄処理
    /// </summary>
    protected virtual void Release() { }
}
