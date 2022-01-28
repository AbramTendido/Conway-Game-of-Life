using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

public class GenerateCells : MonoBehaviour
{
    [SerializeField] private CellStorage m_cellStorage;
    [SerializeField] private GameObject m_cellPrefab;
    [SerializeField] private GameObject m_cellHolder;
    [SerializeField] private GameValuesScriptable m_gameValuesSO;
    [FormerlySerializedAs("m_size")] [SerializeField] private float m_cellSize = 0.5f;
    
    // [Range(1,100)]
    // public int m_row = 10;
    // [Range(1,100)]
    // public int m_column = 10;

    public void StartGenerate()
    {
        m_cellStorage.ClearList();
        GenerateCellGrid();
    }

    private void GenerateCellGrid()
    {
        for (int i = 0; i < m_gameValuesSO.m_column; i++)
        {
            for (int j = 0; j < m_gameValuesSO.m_row; j++)
            {
                float xPos = j * m_cellSize;
                float yPos = i * -m_cellSize;
                
                InstantiateCell(xPos, yPos);
            }
        }
        
        AdjustHolderPosition();
        GenerateNeighbours();
        
    }

    private void GenerateNeighbours()
    {
        for (int i = 0; i < m_cellStorage.CellList.Count; i++)
        {
            Cell curCell = m_cellStorage.CellList[i];

            int leftIndex = i - 1;
            if (leftIndex >= 0)
            {
                curCell.GenerateNeighbor(m_cellStorage.CellList[leftIndex]);
            }
            
            int rightIndex = i + 1;
            if (rightIndex < m_cellStorage.CellList.Count)
            {
                curCell.GenerateNeighbor(m_cellStorage.CellList[rightIndex]);
            }

            int upIndex = i - m_gameValuesSO.m_row;
            if (upIndex >= 0)
            {
                curCell.GenerateNeighbor(m_cellStorage.CellList[upIndex]);
            }

            int downIndex = i + m_gameValuesSO.m_row;
            if (downIndex < m_cellStorage.CellList.Count)
            {
                curCell.GenerateNeighbor(m_cellStorage.CellList[downIndex]);
            }

            int upperLeftIndex = upIndex - 1;
            if (upperLeftIndex >= 0)
            {
                curCell.GenerateNeighbor(m_cellStorage.CellList[upperLeftIndex]);
            }

            int lowerLeftIndex = downIndex - 1;
            if (lowerLeftIndex < m_cellStorage.CellList.Count)
            {
                curCell.GenerateNeighbor(m_cellStorage.CellList[lowerLeftIndex]);
            }

            int upperRightIndex = upIndex + 1;
            if (upperRightIndex >= 0)
            {
                curCell.GenerateNeighbor(m_cellStorage.CellList[upperRightIndex]);
            }

            int lowerRightIndex = downIndex + 1;
            if (lowerRightIndex < m_cellStorage.CellList.Count)
            {
                curCell.GenerateNeighbor(m_cellStorage.CellList[lowerRightIndex]);
            }
        }
    }

    private void InstantiateCell(float p_posX, float p_posY)
    {
        GameObject p_cell = Instantiate(m_cellPrefab, transform);
        p_cell.transform.parent = m_cellHolder.transform;
        p_cell.transform.localPosition = new Vector2(p_posX, p_posY);
        m_cellStorage.AddToStorage(p_cell.GetComponent<Cell>());
        
    }
    
    private void AdjustHolderPosition()
    {
        float gridWidth = (m_gameValuesSO.m_row * m_cellSize)/2;
        float gridHeight = (m_gameValuesSO.m_column * m_cellSize)/2;
        m_cellHolder.transform.localPosition = new Vector3(-gridWidth + m_cellSize , gridHeight - m_cellSize, 0);

    }
}
