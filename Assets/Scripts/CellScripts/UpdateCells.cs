using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpdateCells : MonoBehaviour
{
    [SerializeField] private CellStorage m_cellStorage;
    [SerializeField] private CellGenerationsScriptable m_cellGenerationSO;
    [SerializeField] private ActiveCellsScriptable m_activeCellsSO;
    [SerializeField] private GameValuesScriptable m_gameValuesSO;
    
    // [Range(1.0f,99.0f)]
    // public float m_speed = 60.0f;
    private bool isPlaying;

    public void StartUpdate()
    {
        m_cellGenerationSO.Clear();
        RandActiveCells();
        RunGenerationCount();
    }

    private void RunGenerationCount()
    {
        isPlaying = false;
        float repeatRate = ((100f - m_gameValuesSO.m_speed) / 100f );
        // float repeatRate = m_gameValuesSO.m_speed / 100f * 2 ;
        // Debug.Log(repeatRate);
        StopAllCoroutines();
        isPlaying = true;
        StartCoroutine(RunUpdate(repeatRate));
    }

    private void RandActiveCells()
    {
        foreach (Cell cell in m_cellStorage.CellList)
        {
            int rand = Random.Range(0, 100);
            cell.SetState(rand > 75);
        }
    }
    IEnumerator RunUpdate(float p_speed)
    {
        while (isPlaying)
        {
            yield return new WaitForSeconds(p_speed);
            ChangeGeneration();
        }
        
    }

    private void ChangeGeneration()
    {
        m_cellGenerationSO.AddGeneration();
        m_activeCellsSO.Clear();
        
        foreach (Cell cell in m_cellStorage.CellList)
        {
            cell.ChangeGeneration();
        }
    }

    // private void Update()
    // {
    //     ChangeGeneration();
    // }
}
