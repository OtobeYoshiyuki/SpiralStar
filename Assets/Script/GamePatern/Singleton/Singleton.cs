using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    /// <summary>
    /// �p����̃C���X�^���X�̕ϐ�
    /// </summary>
    private static T s_instance = null;

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static T Instance { get { return s_instance; } }

    /// <summary>
    /// �C���X�^���X������ɌĂ΂�鏈��
    /// </summary>
    private void Awake()
    {
        //�C���X�^���X��NULL�̎�
        if(s_instance == null)
        {
            //�V���O���g���̃C���X�^���X��
            //�h���N���X��Cast����
            s_instance = this as T;

            //�C���X�^���X������������
            s_instance.Init();

            //Destory���Ă΂�Ȃ��悤�ɂ���
            return;
        }

        //�C���X�^���X�����łɐ�������Ă���Ƃ��́A
        //Comporment���폜����
        Destroy(this);
    }

    /// <summary>
    /// MonoBehaviour���p�����ꂽ���ɌĂ΂�鏈��
    /// </summary>
    private void OnDestroy()
    {
        //�C���X�^���X���V���O���g���̎�
        if (s_instance == this)
        {
            //�C���X�^���X��NULL�ɂ���
            s_instance = null;
        }

        //�h���N���X�̉���������Ă�
        Release();
    }

    /// <summary>
    /// �h���N���X�̏���������
    /// </summary>
    protected virtual void Init() { }

    /// <summary>
    /// �h���N���X�̔p������
    /// </summary>
    protected virtual void Release() { }
}
