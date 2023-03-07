using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Object = UnityEngine.Object;

public class TouchInputManager : MonoBehaviour
{
    private ARRaycastManager m_raycastManager;
    [SerializeField] private GameObject m_prefab;

    private void Awake()
    {
        m_raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var result = new List<ARRaycastHit>();
            if (m_raycastManager.Raycast(Input.mousePosition, result, TrackableType.PlaneWithinPolygon))
            {
                Instantiate(m_prefab, result[0].pose.position, Quaternion.identity);
            }
        }
    }
}
