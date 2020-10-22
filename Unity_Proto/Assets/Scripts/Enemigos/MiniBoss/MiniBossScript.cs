using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossScript : MonoBehaviour
{
    private float TimeCounter = 0;
    [SerializeField] GameObject spikePrefab;
    [SerializeField] GameObject spikeCagePrefab;
    [SerializeField] Transform player;

    private int randomNumber;
    public int bossHP =100;


    void Update()
    {
        TimeCounter += Time.deltaTime;

        
        
        if (TimeCounter > 3)
        {
            TimeCounter =0;
            randomNumber = Random.Range (1,10);

            if (randomNumber < 6) { SpikeAttack(); Debug.Log("SpikeAttack");}
            else {SpikeCage(); Debug.Log("SpikeCage"); }
            
        }
        
        
    }


    void SpikeAttack ()
    {
        Instantiate(spikePrefab, player.transform.position, transform.rotation);
    }

    void SpikeCage ()
    {
        Instantiate(spikeCagePrefab, player.transform.position, transform.rotation);
    }
    


}
