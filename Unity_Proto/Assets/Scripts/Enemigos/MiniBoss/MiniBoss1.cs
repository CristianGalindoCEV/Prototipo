using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss1 : MonoBehaviour
{
    private float TimeCounter = 0;
   [SerializeField] GameObject pinchoPrefab;
   [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
        
        if (TimeCounter > 5){
            Instantiate(pinchoPrefab, player.transform.position, transform.rotation);
            TimeCounter =0;
        }
        
        
    }
}
