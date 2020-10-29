using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // StartCoroutine(MeTocan());
            Destroy(gameObject);
        }
    }

   /* IEnumerator MeTocan()
    {
        yield return new WaitForSeconds(1.0f);
        //Sonido
        //Particulas
    }*/
}
