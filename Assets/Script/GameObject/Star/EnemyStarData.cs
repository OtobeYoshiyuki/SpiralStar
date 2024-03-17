using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStarData
{
    /// <summary>
    /// ����������W���w�肷��
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private Vector3 m_spawnLocation = Vector3.zero;

    /// <summary>
    /// �摜�̐F���w�肷��
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private Color m_spriteColor = Color.white;

    /// <summary>
    /// Spawn������W
    /// �Q�b�^�[
    /// </summary>
    public Vector3 location { get { return m_spawnLocation; } }

    /// <summary>
    /// Sprite�̐F
    /// �Q�b�^�[
    /// </summary>
    public Color color { get { return m_spriteColor; } }

}
