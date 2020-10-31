using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraHP : MonoBehaviour
{
    public Image healt;
    public GameMaster gamemaster;
    // Start is called before the first frame update
    void Start()
    {
        gamemaster.hp = gamemaster.maxhp;
    }
    public void TakeDamage(float amount)
    {
        gamemaster.hp = Mathf.Clamp(gamemaster.hp - amount, 0f, gamemaster.maxhp);
        healt.transform.localScale = new Vector2(gamemaster.hp / gamemaster.maxhp, 1);

    }
    public void TakeLife(float amount)
    {
        gamemaster.hp = Mathf.Clamp(gamemaster.hp + amount, 0f, gamemaster.maxhp);
        healt.transform.localScale = new Vector2(gamemaster.hp / gamemaster.maxhp, 1);

    }
}
