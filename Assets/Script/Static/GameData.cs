using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ÓI�N���X
/// �ق���GameObject�ɃA�^�b�`����K�v���Ȃ��̂ŁA
/// Monobehaviour��Singleton�͌p������K�v���Ȃ�
/// Scene���܂����ŏ����󂯓n������ꍇ�ȂǂɎg�p����
/// </summary>
public static class GameData
{
    /// <summary>
    /// key:String
    /// Value:Int
    /// �w�肵���L�[�ɒl��������
    /// </summary>
    private static Dictionary<string, int> s_intDirect = new Dictionary<string, int>();

    /// <summary>
    /// key:String
    /// Value:Float
    /// �w�肵���L�[�ɒl��������
    /// </summary>
    private static Dictionary<string, float> s_floatDirect = new Dictionary<string, float>();

    /// <summary>
    /// key:String
    /// Value:String
    /// �w�肵���L�[�ɒl��������
    /// </summary>
    private static Dictionary<string, string> s_stringDirect = new Dictionary<string, string>();

    /// <summary>
    /// key:String
    /// Value:GameObject
    /// �w�肵���L�[�ɒl��������
    /// </summary>
    private static Dictionary<string, GameObject> s_objectDirect = new Dictionary<string, GameObject>();

    /// <summary>
    /// Dictionary��key��value��ǉ�����
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <param name="value">�l</param>
    public static void AddInt(in string key,in int value) { s_intDirect[key] = value; }

    /// <summary>
    /// Dictionary��key��value��ǉ�����
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <param name="value">�l</param>
    public static void AddFloat(in string key,in float value) { s_floatDirect[key] = value; }

    /// <summary>
    /// Dictionary��key��value��ǉ�����
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <param name="value">�l</param>
    public static void AddString(in string key,in string value) { s_stringDirect[key] = value; }

    /// <summary>
    /// Dictionary��key��value��ǉ�����
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <param name="value">�l</param>
    public static void AddGameObject(in string key,GameObject value) { s_objectDirect[key] = value; }

    /// <summary>
    /// Dictionary��key�ɑΉ�����value��Ԃ�
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <returns>value</returns>
    public static int IntValue(in string key) { return s_intDirect[key]; }

    /// <summary>
    /// Dictionary��key�ɑΉ�����value��Ԃ�
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <returns>value</returns>
    public static float FloatValue(in string key) { return s_floatDirect[key]; }

    /// <summary>
    /// Dictionary��key�ɑΉ�����value��Ԃ�
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <returns>value</returns>
    public static string StringValue(in string key) { return s_stringDirect[key]; }

    /// <summary>
    /// Dictionary��key�ɑΉ�����value��Ԃ�
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <returns>value</returns>
    public static GameObject GameObjectValue(in string key) { return s_objectDirect[key]; }

    /// <summary>
    /// Dictionary��key�����݂��邩�ǂ����m�F����
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <returns>���݂���ꍇtrue ���݂��Ȃ��ꍇfalse</returns>
    public static bool FindInt(in string key) { return s_intDirect.ContainsKey(key); }

    /// <summary>
    /// Dictionary��key�����݂��邩�ǂ����m�F����
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <returns>���݂���ꍇtrue ���݂��Ȃ��ꍇfalse</returns>
    public static bool FindFloat(in string key) { return s_floatDirect.ContainsKey(key); }

    /// <summary>
    /// Dictionary��key�����݂��邩�ǂ����m�F����
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <returns>���݂���ꍇtrue ���݂��Ȃ��ꍇfalse</returns>
    public static bool FindString(in string key) { return s_stringDirect.ContainsKey(key); }

    /// <summary>
    /// Dictionary��key�����݂��邩�ǂ����m�F����
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <returns>���݂���ꍇtrue ���݂��Ȃ��ꍇfalse</returns>
    public static bool FindGameObject(in string key) { return s_objectDirect.ContainsKey(key); }
}
