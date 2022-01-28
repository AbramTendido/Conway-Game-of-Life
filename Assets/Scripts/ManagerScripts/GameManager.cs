using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoManager<GameManager>
{
    [SerializeField] public CellColorScriptable m_cellColorSO;
    [SerializeField] public CellGenerationsScriptable m_cellGenerationSO;
    [SerializeField] public ActiveCellsScriptable m_activeCellsSO;
    
    [SerializeField] private GenerateCells m_generateCells;
    [SerializeField] private UpdateCells m_updateCells;

    private void Start()
    {
        m_cellGenerationSO.Clear();
        m_activeCellsSO.Clear();
        // Play();
    }

    public void Play()
    {
        m_generateCells.StartGenerate();
        m_updateCells.StartUpdate();
    }
}
