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

    private bool moveToNext;
    public float waitTime;

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (moveToNext)
        {
            StopCoroutine(WaitForMove(0));
            platformPoint.MovePosition(Vector3.MoveTowards(platformPoint.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        }
      
        if (Vector3.Distance(platformPoint.position, platformPositions[nextPosition].position) <= 0)
        {
            StartCoroutine(WaitForMove(waitTime));
            acutalPosition = nextPosition;
            nextPosition++;

            if (nextPosition > platformPositions.Length - 1)
            {
                nextPosition = 0;
            }
        }
    }
    IEnumerator WaitForMove(float time)
    {
        moveToNext = false;
        yield return new WaitForSeconds(time);
        moveToNext = true;
    }

}
