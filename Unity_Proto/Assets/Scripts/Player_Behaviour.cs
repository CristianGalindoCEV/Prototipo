﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Behaviour : MonoBehaviour
{
    private float m_horizontalMove;
    private float m_verticalMove;
    public CharacterController player;
    private Vector3 PlayerInput;
   
    [SerializeField] private float m_playerspeed = 15;
    private Vector3 movePlayer;
    [SerializeField] private float gravity = 70f;
    private float m_fallVelocity;
    [SerializeField] private float m_jumpForce = 20f;
    [SerializeField] private int HP = 100;
    [SerializeField] private bool iamDead = false;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    void Start()
    {

        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        m_horizontalMove = Input.GetAxis("Horizontal");
        m_verticalMove = Input.GetAxis("Vertical");

        PlayerInput = new Vector3(m_horizontalMove, 0, m_verticalMove);
        PlayerInput = Vector3.ClampMagnitude(PlayerInput, 5);

        camDirection();

        movePlayer = PlayerInput.x * camRight + PlayerInput.z * camForward;

        movePlayer = movePlayer * m_playerspeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        PlayerSkills();

        //le asigno el movimiento al player
        player.Move(movePlayer * Time.deltaTime);

    }

    //Funcion de camara
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
   
    //Funcion de gravedad
    void SetGravity()
    {
        if (player.isGrounded)
        {
            m_fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = m_fallVelocity;
        }
        else
        {
            m_fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = m_fallVelocity; 
        }
    }
   
    //Habilidades del player
    void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            m_fallVelocity = m_jumpForce;
            movePlayer.y = m_fallVelocity;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine(Golpe());
        }
        if (other.tag == "Finish")
        {
            SceneManager.LoadScene("GameOver");
        }
        if (other.tag == "portal")
        {
            SceneManager.LoadScene("EscenaMiniBoss");
        }
    }

    IEnumerator Golpe()
    {
        //Indico que estoy muerto
        iamDead = true;
        //Indicamos al score que hemos perdido una vida
        HP = HP - 10;
       
       /* if (HP == 0)
        {
            //Salta a la pantalla de muerte
        }*/
        yield return new WaitForSeconds(1.0f);
        iamDead = false;


    }
}
