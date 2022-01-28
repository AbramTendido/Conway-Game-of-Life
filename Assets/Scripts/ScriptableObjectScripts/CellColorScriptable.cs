using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSO", menuName = "ScriptableObjects/ColorSO", order = 1)]
public class CellColorScriptable : ScriptableObject
{
    public Color m_activeColor;
    public Color m_inactiveColor;

    public void SetActiveColor(int p_index)
    {
        switch (p_index)
        {
            case 0 :
                m_activeColor = Color.white;
                break;
            case 1 :
                m_activeColor = Color.cyan;
                break;
            case 2 :
                m_activeColor = Color.green;
                break;
        }
    }

    public void SetInactiveColor(int p_index)
    {
        switch (p_index)
        {
            case 0 :
                m_inactiveColor = Color.black;
                break;
            case 1 :
                m_inactiveColor = Color.red;
                break;
            case 2 :
                m_inactiveColor = Color.blue;
                break;
        }
    }
}
