using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 静的クラス
/// ほかのGameObjectにアタッチする必要がないので、
/// MonobehaviourやSingletonは継承する必要がない
/// </summary>
public static class Utility
{
    /// <summary>
    /// 数値をカスタマイズして文字列に変換する
    /// </summary>
    /// <param name="value">文字列に変換する数値</param>
    /// <param name="format">文字列に変換する際のフォーマット</param>
    /// <param name="maxNumber">数値の最大桁数</param>
    /// <param name="pushStr">先頭に挿入する文字</param>
    /// <returns>カスタマイズした文字</returns>
    public static string ValueCustomFrontString(in float value,in string format,in int maxNumber,in string pushStr)
    {
        //ベクトルを整数の偶数に丸め込む
        string str = value.ToString(format);

        //for分を回す数を求める
        int num = Mathf.Abs(str.Length - maxNumber);

        for (int i = 0; i < num; i++)
        {
            //桁数に応じて、文字の先頭に指定した文字を挿入する
            str = str.Insert(0, pushStr);
        }

        //カスタマイズした文字列を返す
        return str;
    }

    /// <summary>
    /// 2点の間の角度を求める
    /// </summary>
    /// <param name="start">始点</param>
    /// <param name="target">終点</param>
    /// <returns>角度（Degree）</returns>
    public static float Atan2DegAngle(in Vector2 start,in Vector2 target)
    {
        //ベクトルの距離を算出する
        Vector2 length = target - start;

        //角度を算出する（Radian）
        float radian = Mathf.Atan2(length.x, length.y);

        //RadianをDegreeに変換する
        float degree = radian * Mathf.Rad2Deg;

        //Degreeを返す
        return degree;
    }

    /// <summary>
    /// 2点間のベクトルの長さを求める
    /// </summary>
    /// <param name="start">計算のもととなる座標</param>
    /// <param name="target">計算する相手の座標</param>
    /// <returns>ベクトルの長さ</returns>
    public static float VectorLength(in Vector3 start,in Vector3 target)
    {
        //ベクトルの距離を算出する
        Vector3 length = target - start;

        //ベクトルの長さを求めて返す
        return length.magnitude;
    }

    /// <summary>
    /// 現在の力を算出する
    /// </summary>
    /// <param name="force">現在の力</param>
    /// <param name="scalar">スカラ値</param>
    /// <returns></returns>
    public static float ForceFloat(in Vector3 force,in float scalar)
    {
        //ベクトルの大きさをスカラ倍する
        float length = force.magnitude * scalar;

        //算出した値を返す
        return length;
    }

    /// <summary>
    /// 指定したSpriteのアルファ値を変更する
    /// </summary>
    /// <param name="sprite">対象の画像</param>
    /// <param name="alfa">透明度</param>
    /// <returns>新たに設定した色</returns>
    public static Color SetColorOpacity(SpriteRenderer sprite,in float alfa)
    {
        //色情報を取得する
        Color color = sprite.color;

        //新たな色を設定する
        Color newColor = new Color(color.r, color.g, color.b, alfa);

        //設定した色を返す
        return newColor;
    }

    /// <summary>
    /// テクスチャの色を合成する関数
    /// </summary>
    /// <param name="sprite">対象の画像</param>
    /// <param name="color1">合成する色</param>
    /// <param name="color2">合成する色</param>
    /// <returns>合成後の色</returns>
    public static Color SetColorAddtive(Color color1,Color color2,
        Action<SpriteRenderer,float> action = null,SpriteRenderer sprite = null,in float alfa = 1.0f)
    {
        //色を掛け合わせる
        Color color = color1 * color2;

        //アルファ値を変更する
        action?.Invoke(sprite,alfa);

        //変更した色を返す
        return color;
    }

    /// <summary>
    /// クラス名からTypeを取得する関数
    /// </summary>
    /// <param name="name">クラス名</param>
    /// <returns>Type</returns>
    public static Type GetTypeClassName(in string name)
    {
        //指定したクラス名のTypeを取得する
        Type type = System.Reflection.Assembly.Load("UnityEngine.dll").GetType(name);

        //Typeを返す
        return type;
    }

    /// <summary>
    /// 計算結果がマイナスになった超過分を求める
    /// </summary>
    /// <param name="hp">現在のHp</param>
    /// <param name="damage">受けたダメージ</param>
    /// <param name="max">Hpの最大値</param>
    /// <returns></returns>
    public static float OverClampDecrease(float hp, float damage, float max)
    {
        //Hpの範囲を限定する
        float over = Mathf.Clamp(hp - damage, -max, 0);

        //超えた分の値を求める
        float abs = Mathf.Abs(over);

        //超えた分の値を返す
        return abs;
    }

    /// <summary>
    /// 計算結果を絶対値で返す
    /// </summary>
    /// <param name="i1">第1引数</param>
    /// <param name="i2">第2引数</param>
    /// <returns>計算結果(絶対値)</returns>
    public static int AbsCaclInt(int i1,int i2)
    {
        //計算結果を絶対値で返す
        return Mathf.Abs(i1 - i2);
    }
}
