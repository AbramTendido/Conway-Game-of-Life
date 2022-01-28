using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoManager<GameUIManager>
{
    [SerializeField] private CellColorScriptable m_cellColorSO;
    [SerializeField] private GameValuesScriptable m_gameValuesSO;
    
    [SerializeField] private TextMeshProUGUI m_currGenerationText;
    [SerializeField] private TextMeshProUGUI m_currActiveText;
    [SerializeField] private TextMeshProUGUI m_currRowText;
    [SerializeField] private TextMeshProUGUI m_currColumnText;

    [SerializeField] private Slider m_speedSlider;
    [SerializeField] private Slider m_rowSlider;
    [SerializeField] private Slider m_columnSlider;

    public void Play()
    {
        GameManager.Instance.Play();
    }
    public void UpdateGenerationText()
    {
        m_currGenerationText.text = GameManager.Instance.m_cellGenerationSO.m_generationCount.ToString();
    }

    public void UpdateActiveCountText()
    {
        m_currActiveText.text = GameManager.Instance.m_activeCellsSO.m_activeCount.ToString();
    }

    public void UpdateSpeedSlider()
    {
        m_gameValuesSO.m_speed = m_speedSlider.value;
    }

    public void UpdateRowSlider()
    {
        m_gameValuesSO.m_row = (int)m_rowSlider.value;
        m_currRowText.text = m_gameValuesSO.m_row.ToString();
    }

    public void UpdateColumnSlider()
    {
        m_gameValuesSO.m_column = (int)m_columnSlider.value;
        m_currColumnText.text = m_gameValuesSO.m_column.ToString();
    }

    public void ChangeActiveColor(int p_index)
    {
        m_cellColorSO.SetActiveColor(p_index);
    }

    public void ChangeInactiveColor(int p_index)
    {
        m_cellColorSO.SetInactiveColor(p_index);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}
