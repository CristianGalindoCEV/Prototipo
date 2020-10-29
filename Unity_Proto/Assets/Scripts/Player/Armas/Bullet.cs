using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : FireTemplate
{
    public float throughForce;

    public override void Fire()
    {
        GetComponent<Rigidbody>().AddForce(throughForce * transform.forward, ForceMode.Impulse);
    }

    public override void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}