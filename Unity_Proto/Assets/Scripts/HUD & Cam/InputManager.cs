using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject Bauculo;
    [SerializeField] private GameObject Espada;
    public bool BauculoItem = false;
    public bool EspadaItem = true;
    public GameMaster gamemaster;
    // Start is called before the first frame update
    void Start()
    {
        Bauculo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (BauculoItem == true)
        {
            Espada.SetActive(false);
            Bauculo.SetActive(true);
            EspadaItem = (false);
            if (Input.GetButtonDown("Fire1"))
            {
                //Bauculo.Fire();
            }
        }
        else if (EspadaItem == true)
        {
            Espada.SetActive(true);
            Bauculo.SetActive(false);
            BauculoItem = (false);
            if (Input.GetButtonDown("Fire1"))
            {
                //Espada.Fire();
            }
        }
        if (Input.GetKey("1"))
        {
            EspadaItem = true;
            BauculoItem = false;
        }
        
         if (Input.GetKey("2") && gamemaster.unlocked == true)
         {
            BauculoItem = true;
            EspadaItem = false;
         }
        
    }


}
