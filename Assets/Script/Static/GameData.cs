using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 静的クラス
/// ほかのGameObjectにアタッチする必要がないので、
/// MonobehaviourやSingletonは継承する必要がない
/// Sceneをまたいで情報を受け渡しする場合などに使用する
/// </summary>
public static class GameData
{
    /// <summary>
    /// key:String
    /// Value:Int
    /// 指定したキーに値を代入する
    /// </summary>
    private static Dictionary<string, int> s_intDirect = new Dictionary<string, int>();

    /// <summary>
    /// key:String
    /// Value:Float
    /// 指定したキーに値を代入する
    /// </summary>
    private static Dictionary<string, float> s_floatDirect = new Dictionary<string, float>();

    /// <summary>
    /// key:String
    /// Value:String
    /// 指定したキーに値を代入する
    /// </summary>
    private static Dictionary<string, string> s_stringDirect = new Dictionary<string, string>();

    /// <summary>
    /// key:String
    /// Value:GameObject
    /// 指定したキーに値を代入する
    /// </summary>
    private static Dictionary<string, GameObject> s_objectDirect = new Dictionary<string, GameObject>();

    /// <summary>
    /// Dictionaryのkeyにvalueを追加する
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="value">値</param>
    public static void AddInt(in string key,in int value) { s_intDirect[key] = value; }

    /// <summary>
    /// Dictionaryのkeyにvalueを追加する
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="value">値</param>
    public static void AddFloat(in string key,in float value) { s_floatDirect[key] = value; }

    /// <summary>
    /// Dictionaryのkeyにvalueを追加する
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="value">値</param>
    public static void AddString(in string key,in string value) { s_stringDirect[key] = value; }

    /// <summary>
    /// Dictionaryのkeyにvalueを追加する
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="value">値</param>
    public static void AddGameObject(in string key,GameObject value) { s_objectDirect[key] = value; }

    /// <summary>
    /// Dictionaryのkeyに対応するvalueを返す
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>value</returns>
    public static int IntValue(in string key) { return s_intDirect[key]; }

    /// <summary>
    /// Dictionaryのkeyに対応するvalueを返す
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>value</returns>
    public static float FloatValue(in string key) { return s_floatDirect[key]; }

    /// <summary>
    /// Dictionaryのkeyに対応するvalueを返す
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>value</returns>
    public static string StringValue(in string key) { return s_stringDirect[key]; }

    /// <summary>
    /// Dictionaryのkeyに対応するvalueを返す
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>value</returns>
    public static GameObject GameObjectValue(in string key) { return s_objectDirect[key]; }

    /// <summary>
    /// Dictionaryのkeyが存在するかどうか確認する
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>存在する場合true 存在しない場合false</returns>
    public static bool FindInt(in string key) { return s_intDirect.ContainsKey(key); }

    /// <summary>
    /// Dictionaryのkeyが存在するかどうか確認する
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>存在する場合true 存在しない場合false</returns>
    public static bool FindFloat(in string key) { return s_floatDirect.ContainsKey(key); }

    /// <summary>
    /// Dictionaryのkeyが存在するかどうか確認する
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>存在する場合true 存在しない場合false</returns>
    public static bool FindString(in string key) { return s_stringDirect.ContainsKey(key); }

    /// <summary>
    /// Dictionaryのkeyが存在するかどうか確認する
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>存在する場合true 存在しない場合false</returns>
    public static bool FindGameObject(in string key) { return s_objectDirect.ContainsKey(key); }
}
