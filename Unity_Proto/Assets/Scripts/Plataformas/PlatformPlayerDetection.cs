using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerDetection : MonoBehaviour
{

    private Transform m_myTransform;

    private void Start()
    {
        m_myTransform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = m_myTransform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
