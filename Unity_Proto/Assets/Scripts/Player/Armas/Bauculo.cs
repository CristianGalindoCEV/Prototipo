using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bauculo : MonoBehaviour
{
    [SerializeField] private FireTemplate bullet;
    [SerializeField] private GameObject mano;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fire()
    {
        // Debug.Log("Fire");

        // Instanciar una pelota
        FireTemplate pelota = Instantiate(bullet, mano.transform.position, mano.transform.rotation) as FireTemplate;

        // Ponerla en la posición del player
        // Dispararla
        pelota.Fire();
    }
}
