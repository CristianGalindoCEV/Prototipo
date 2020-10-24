using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraHP : MonoBehaviour
{
    public Image healt;

    float hp, maxHp = 100f;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        healt.transform.localScale = new Vector2(hp/maxHp, 1);

    }
    public void TakeLife(float amount)
    {
        hp = Mathf.Clamp(hp + amount, 0f, maxHp);
        healt.transform.localScale = new Vector2(hp / maxHp, 1);

    }
}
