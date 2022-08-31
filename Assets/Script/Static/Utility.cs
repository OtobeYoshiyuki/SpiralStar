using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �ÓI�N���X
/// �ق���GameObject�ɃA�^�b�`����K�v���Ȃ��̂ŁA
/// Monobehaviour��Singleton�͌p������K�v���Ȃ�
/// </summary>
public static class Utility
{
    /// <summary>
    /// ���l���J�X�^�}�C�Y���ĕ�����ɕϊ�����
    /// </summary>
    /// <param name="value">������ɕϊ����鐔�l</param>
    /// <param name="format">������ɕϊ�����ۂ̃t�H�[�}�b�g</param>
    /// <param name="maxNumber">���l�̍ő包��</param>
    /// <param name="pushStr">�擪�ɑ}�����镶��</param>
    /// <returns>�J�X�^�}�C�Y��������</returns>
    public static string ValueCustomFrontString(in float value,in string format,in int maxNumber,in string pushStr)
    {
        //�x�N�g���𐮐��̋����Ɋۂߍ���
        string str = value.ToString(format);

        //for�����񂷐������߂�
        int num = Mathf.Abs(str.Length - maxNumber);

        for (int i = 0; i < num; i++)
        {
            //�����ɉ����āA�����̐擪�Ɏw�肵��������}������
            str = str.Insert(0, pushStr);
        }

        //�J�X�^�}�C�Y�����������Ԃ�
        return str;
    }

    /// <summary>
    /// 2�_�̊Ԃ̊p�x�����߂�
    /// </summary>
    /// <param name="start">�n�_</param>
    /// <param name="target">�I�_</param>
    /// <returns>�p�x�iDegree�j</returns>
    public static float Atan2DegAngle(in Vector2 start,in Vector2 target)
    {
        //�x�N�g���̋������Z�o����
        Vector2 length = target - start;

        //�p�x���Z�o����iRadian�j
        float radian = Mathf.Atan2(length.x, length.y);

        //Radian��Degree�ɕϊ�����
        float degree = radian * Mathf.Rad2Deg;

        //Degree��Ԃ�
        return degree;
    }

    /// <summary>
    /// 2�_�Ԃ̃x�N�g���̒��������߂�
    /// </summary>
    /// <param name="start">�v�Z�̂��ƂƂȂ���W</param>
    /// <param name="target">�v�Z���鑊��̍��W</param>
    /// <returns>�x�N�g���̒���</returns>
    public static float VectorLength(in Vector3 start,in Vector3 target)
    {
        //�x�N�g���̋������Z�o����
        Vector3 length = target - start;

        //�x�N�g���̒��������߂ĕԂ�
        return length.magnitude;
    }

    /// <summary>
    /// ���݂̗͂��Z�o����
    /// </summary>
    /// <param name="force">���݂̗�</param>
    /// <param name="scalar">�X�J���l</param>
    /// <returns></returns>
    public static float ForceFloat(in Vector3 force,in float scalar)
    {
        //�x�N�g���̑傫�����X�J���{����
        float length = force.magnitude * scalar;

        //�Z�o�����l��Ԃ�
        return length;
    }

    /// <summary>
    /// �w�肵��Sprite�̃A���t�@�l��ύX����
    /// </summary>
    /// <param name="sprite">�Ώۂ̉摜</param>
    /// <param name="alfa">�����x</param>
    /// <returns>�V���ɐݒ肵���F</returns>
    public static Color SetColorOpacity(SpriteRenderer sprite,in float alfa)
    {
        //�F�����擾����
        Color color = sprite.color;

        //�V���ȐF��ݒ肷��
        Color newColor = new Color(color.r, color.g, color.b, alfa);

        //�ݒ肵���F��Ԃ�
        return newColor;
    }

    /// <summary>
    /// �e�N�X�`���̐F����������֐�
    /// </summary>
    /// <param name="sprite">�Ώۂ̉摜</param>
    /// <param name="color1">��������F</param>
    /// <param name="color2">��������F</param>
    /// <returns>������̐F</returns>
    public static Color SetColorAddtive(Color color1,Color color2,
        Action<SpriteRenderer,float> action = null,SpriteRenderer sprite = null,in float alfa = 1.0f)
    {
        //�F���|�����킹��
        Color color = color1 * color2;

        //�A���t�@�l��ύX����
        action?.Invoke(sprite,alfa);

        //�ύX�����F��Ԃ�
        return color;
    }

    /// <summary>
    /// �N���X������Type���擾����֐�
    /// </summary>
    /// <param name="name">�N���X��</param>
    /// <returns>Type</returns>
    public static Type GetTypeClassName(in string name)
    {
        //�w�肵���N���X����Type���擾����
        Type type = System.Reflection.Assembly.Load("UnityEngine.dll").GetType(name);

        //Type��Ԃ�
        return type;
    }

    /// <summary>
    /// �v�Z���ʂ��}�C�i�X�ɂȂ������ߕ������߂�
    /// </summary>
    /// <param name="hp">���݂�Hp</param>
    /// <param name="damage">�󂯂��_���[�W</param>
    /// <param name="max">Hp�̍ő�l</param>
    /// <returns></returns>
    public static float OverClampDecrease(float hp, float damage, float max)
    {
        //Hp�͈̔͂����肷��
        float over = Mathf.Clamp(hp - damage, -max, 0);

        //���������̒l�����߂�
        float abs = Mathf.Abs(over);

        //���������̒l��Ԃ�
        return abs;
    }

    /// <summary>
    /// �v�Z���ʂ��Βl�ŕԂ�
    /// </summary>
    /// <param name="i1">��1����</param>
    /// <param name="i2">��2����</param>
    /// <returns>�v�Z����(��Βl)</returns>
    public static int AbsCaclInt(int i1,int i2)
    {
        //�v�Z���ʂ��Βl�ŕԂ�
        return Mathf.Abs(i1 - i2);
    }
}
