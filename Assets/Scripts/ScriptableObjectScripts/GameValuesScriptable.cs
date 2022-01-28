using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameValuesSO", menuName = "ScriptableObjects/GameValuesSO", order = 4)]
public class GameValuesScriptable : ScriptableObject
{
    [Range(1.0f,99.0f)]
    public float m_speed;
    [Range(1,100)]
    public int m_row;
    [Range(1,100)]
    public int m_column;

    public int m_rand;
}
