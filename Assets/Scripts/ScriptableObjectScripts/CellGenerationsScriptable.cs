using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CellGenerationSO", menuName = "ScriptableObjects/CellGenerationSO", order = 2)]
public class CellGenerationsScriptable : ScriptableObject
{
    public int m_generationCount;

    public void AddGeneration()
    {
        m_generationCount++;
        GameUIManager.Instance.UpdateGenerationText();
    }

    public void Clear()
    {
        m_generationCount = 0;
    }
}
