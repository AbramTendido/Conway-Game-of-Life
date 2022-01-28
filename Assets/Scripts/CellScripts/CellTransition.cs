using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellTransition
{
    private int m_activeCellCount;

    public void AddActiveCellCount()
    {
        m_activeCellCount++;
    }

    public CellState Transition(CellState p_cellState)
    {
        if (p_cellState == CellState.Active)
        {
            if (m_activeCellCount < 2)
            {
                return CellState.InActive;
            }

            if (m_activeCellCount >= 2 && m_activeCellCount <= 3)
            {
                return CellState.Active;
            }

            if (m_activeCellCount > 3)
            {
                return CellState.InActive;
            }
        }
        else
        {
            if (m_activeCellCount == 3)
            {
                return CellState.Active;
            }
        }

        return CellState.InActive;
    }
    
    public void Clear()
    {
        m_activeCellCount = 0;
    }
}
