using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BauculoItem : MonoBehaviour
{
    [SerializeField] private int m_speed = 30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.back, m_speed * Time.deltaTime);
    }

    //triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Decirle al imput manager que desbloqueado es true
            StartCoroutine(Desbloqueado());
        }
    }
    IEnumerator Desbloqueado()
    {
       //Particula
       //Sonido
        yield return new WaitForSeconds(1.0f);
        Destroy (gameObject);
    }
}
