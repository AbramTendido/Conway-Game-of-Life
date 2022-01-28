using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActiveCellsSO", menuName = "ScriptableObjects/ActiveCellsSO", order = 3)]
public class ActiveCellsScriptable : ScriptableObject
{
    public int m_activeCount;

    public void AddActive()
    {
        m_activeCount++;
        GameUIManager.Instance.UpdateActiveCountText();
    }

    public void Clear()
    {
        m_activeCount = 0;
    }
}
