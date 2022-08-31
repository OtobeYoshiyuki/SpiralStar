using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// KeyValuePairの拡張メソッド
/// </summary>
public static class KeyValueExtension
{
    /// <summary>
    /// 新たなKeyを設定する(Valueはそのまま)
    /// </summary>
    /// <typeparam name="Tkey">keyの型</typeparam>
    /// <typeparam name="Tvalue">vakueの型</typeparam>
    /// <param name="pair">対象のpairの変数</param>
    /// <param name="key">新しいkey</param>
    /// <returns>設定しなおしたpair</returns>
    public static KeyValuePair<Tkey, Tvalue> SetKey<Tkey,Tvalue>(this KeyValuePair<Tkey,Tvalue> pair,Tkey key)
    {
        //新たにkeyを設定しなおす
        pair = new KeyValuePair<Tkey, Tvalue>(key, pair.Value);

        //設定しなおしたpairを返す
        return pair;
    }

    /// <summary>
    /// 新たなValueを設定する(Keyはそのまま)
    /// </summary>
    /// <typeparam name="Tkey">keyの型</typeparam>
    /// <typeparam name="Tvalue">valueの型</typeparam>
    /// <param name="pair">対象のpairの変数</param>
    /// <param name="value">新しいvalue</param>
    /// <returns>設定しなおしたpair</returns>
    public static KeyValuePair<Tkey, Tvalue> SetValue<Tkey,Tvalue>(this KeyValuePair<Tkey,Tvalue> pair,Tvalue value)
    {
        //新たにvalueを設定しなおす
        pair = new KeyValuePair<Tkey, Tvalue>(pair.Key, value);

        //設定しなおしたpairを返す
        return pair;
    }
}
