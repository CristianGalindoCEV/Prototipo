﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMeele : MonoBehaviour
{

    //Player
    [SerializeField] private float speedChase = 5.5f;
    public int Damage = 10;
    private float speed = 6f;

    //Rango
    [SerializeField] float rangeDistanceMin;
    [SerializeField] float rangeDistanceMax;
    float rangeDistance = 6;
    [SerializeField] Transform player;
    public SpacePoint[] puntos;
    int currentPoint = 0;


    private void Awake()
    {
        rangeDistance = rangeDistanceMin;
       
    }
    void Update()
    {
        
        //Miramos si hemos llegado al punto actual
        if(Vector3.Distance(transform.position, puntos[currentPoint].transform.position)< 0.2f){
            currentPoint++;
            currentPoint %= puntos.Length;
        }

        //Detecta Player
        if (Mathf.Abs(Vector3.Distance(player.position, transform.position)) < rangeDistance)
        {
            rangeDistance = rangeDistanceMax;    
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speedChase);
        }

        //Patrulla siguiente punto
        else
        {
            rangeDistance = rangeDistanceMin;
            transform.position = Vector3.MoveTowards(transform.position, puntos[currentPoint].transform.position, Time.deltaTime * speed);
            
        }
    }

    //Trigers
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Ataco());
        }
    }

    //Ataque
        IEnumerator Ataco()
    {
        speedChase = 0f;
        //Animacion
        yield return new WaitForSeconds(2.0f);
        speedChase = 5.5f;
    }


}

