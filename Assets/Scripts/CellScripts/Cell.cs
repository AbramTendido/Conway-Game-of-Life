using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    private CellTransition m_cellTransition = new CellTransition();
    private CellState m_cellState = CellState.InActive;

    private List<Cell> m_cellNeighbours = new List<Cell>();

    public void SetState(bool p_isActive)
    {
        if (p_isActive)
        {
            m_cellState = CellState.Active;
            ChangeCellColor(GameManager.Instance.m_cellColorSO.m_activeColor);
        }
        else
        {
            m_cellState = CellState.InActive;
            ChangeCellColor(GameManager.Instance.m_cellColorSO.m_inactiveColor);
        }
    }

    public void ChangeGeneration()
    {
        m_cellTransition.Clear();

        foreach (Cell cell in m_cellNeighbours)
        {
            if (cell.m_cellState == CellState.Active)
            {
                m_cellTransition.AddActiveCellCount();
            }
        }
        CellTransition();
    }

    private void CellTransition()
    {
        CellState cellState = m_cellTransition.Transition(m_cellState);

        m_cellState = cellState;
        if (m_cellState == CellState.Active)
        {
            GameManager.Instance.m_activeCellsSO.AddActive();
            ChangeCellColor(GameManager.Instance.m_cellColorSO.m_activeColor);
        }
        else
        {
            ChangeCellColor(GameManager.Instance.m_cellColorSO.m_inactiveColor);
        }
    }

    public void GenerateNeighbor(Cell p_cell)
    {
        m_cellNeighbours.Add(p_cell);
    }

    public void CellPosition(Vector2 p_position)
    {
        gameObject.transform.localPosition = p_position;
    }

    public void ChangeCellColor(Color p_color)
    {
        m_spriteRenderer.color = p_color;
    }
}

public enum CellState
{
    Active,
    InActive
}
