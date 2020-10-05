using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{

    [SerializeField] private float m_speed = 4;
    [SerializeField] private Transform myTransform;
    private float m_xAxis, m_zAxis;


    void Start()
    {
        myTransform = GetComponent<Transform>();
    }
   
    void Update()
    {
        m_xAxis = Input.GetAxis("Horizontal");
        m_zAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(- m_xAxis, 0,- m_zAxis);
        myTransform.Translate(movement * m_speed * Time.deltaTime);
    }
}
