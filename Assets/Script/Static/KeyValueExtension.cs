using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// KeyValuePair�̊g�����\�b�h
/// </summary>
public static class KeyValueExtension
{
    /// <summary>
    /// �V����Key��ݒ肷��(Value�͂��̂܂�)
    /// </summary>
    /// <typeparam name="Tkey">key�̌^</typeparam>
    /// <typeparam name="Tvalue">vakue�̌^</typeparam>
    /// <param name="pair">�Ώۂ�pair�̕ϐ�</param>
    /// <param name="key">�V����key</param>
    /// <returns>�ݒ肵�Ȃ�����pair</returns>
    public static KeyValuePair<Tkey, Tvalue> SetKey<Tkey,Tvalue>(this KeyValuePair<Tkey,Tvalue> pair,Tkey key)
    {
        //�V����key��ݒ肵�Ȃ���
        pair = new KeyValuePair<Tkey, Tvalue>(key, pair.Value);

        //�ݒ肵�Ȃ�����pair��Ԃ�
        return pair;
    }

    /// <summary>
    /// �V����Value��ݒ肷��(Key�͂��̂܂�)
    /// </summary>
    /// <typeparam name="Tkey">key�̌^</typeparam>
    /// <typeparam name="Tvalue">value�̌^</typeparam>
    /// <param name="pair">�Ώۂ�pair�̕ϐ�</param>
    /// <param name="value">�V����value</param>
    /// <returns>�ݒ肵�Ȃ�����pair</returns>
    public static KeyValuePair<Tkey, Tvalue> SetValue<Tkey,Tvalue>(this KeyValuePair<Tkey,Tvalue> pair,Tvalue value)
    {
        //�V����value��ݒ肵�Ȃ���
        pair = new KeyValuePair<Tkey, Tvalue>(pair.Key, value);

        //�ݒ肵�Ȃ�����pair��Ԃ�
        return pair;
    }
}
