using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Movil : MonoBehaviour
{
    public Rigidbody platformPoint;
    public Transform[] platformPositions;
    public float platformSpeed;

    private int acutalPosition = 0;
    private int nextPosition = 1;

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        platformPoint.MovePosition(Vector3.MoveTowards(platformPoint.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
    
        if (Vector3.Distance(platformPoint.position, platformPositions[nextPosition].position) <= 0)
        {
            acutalPosition = nextPosition;
            nextPosition++;

            if (nextPosition > platformPositions.Length - 1)
            {
                nextPosition = 0;
            }
        }
    }
}
