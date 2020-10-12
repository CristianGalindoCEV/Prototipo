using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Boton : MonoBehaviour
{
    public void PulsaRetry()
    {
        SceneManager.LoadScene("EscenarioFinal");
    }

    public void PulsaExit()
    {
        Application.Quit();
    }
}
