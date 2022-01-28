using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoManager<CameraManager>
{
    [SerializeField] private Camera m_mainCamera;
    
    [SerializeField] private float m_zoomSpeed = 10.0f;
    [SerializeField] private float m_zoomMin = 25.0f;
    [SerializeField] private float m_zoomMax = 100.0f;
    
    void Update()
    {
        MouseScrollZoom();
    }

    private void MouseScrollZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            m_mainCamera.orthographicSize += m_zoomSpeed;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            m_mainCamera.orthographicSize -= m_zoomSpeed;
        }

        m_mainCamera.orthographicSize = Mathf.Clamp(m_mainCamera.orthographicSize, m_zoomMin, m_zoomMax);
    }
}
