using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{

    public float moveSpeed = 5;
    public float rotateSpeed = 180;
    public float jumpSpeed = 20;
    public float gravity = 9.8f;
    CharacterController controller;
    Vector3 currentMovement;

    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);

        currentMovement = new Vector3(0, currentMovement.y, Input.GetAxis("Vertical") * moveSpeed);
        currentMovement = transform.rotation * currentMovement;

        if (!controller.isGrounded)
            currentMovement -= new Vector3(0, gravity * Time.deltaTime, 0);
        else
            currentMovement.y = 0;

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
            currentMovement.y = jumpSpeed;

        controller.Move(currentMovement * Time.deltaTime);
    }
}
