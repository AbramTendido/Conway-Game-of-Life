using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellStorage : MonoBehaviour
{
    public List<Cell> CellList = new List<Cell>();

    public void AddToStorage(Cell p_cell)
    {
        CellList.Add(p_cell);
    }

    public void ClearList()
    {
        if (CellList.Count > 0)
        {
            foreach (Cell cell in CellList)
            {
                Destroy(cell.gameObject);   
            }
            
            CellList.Clear();
        }
    }
}
