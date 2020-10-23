using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_platform : MonoBehaviour
{

    CharacterController characterController;
    Vector3 groundPos;
    Vector3 lastGroundPos;
    Vector3 currentPos;

    string groundName;
    string lastGroundName;

    bool isJump;

    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "platform")
        {
            if (!isJump)
            {
                RaycastHit hit;
                if (Physics.SphereCast(transform.position, characterController.radius, -transform.up, out hit))
                {
                    GameObject inGround = hit.collider.gameObject;
                    groundName = inGround.name;
                    groundPos = inGround.transform.position;

                    if (groundPos != lastGroundPos && groundName == lastGroundName)
                    {
                        currentPos = Vector3.zero;
                        currentPos += groundPos - lastGroundPos;
                        characterController.Move(currentPos);
                    }
                    lastGroundName = groundName;
                    lastGroundPos = groundPos;
                }
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (!characterController.isGrounded)
                {
                    currentPos = Vector3.zero;
                    lastGroundPos = Vector3.zero;
                    lastGroundName = null;
                    isJump = true;
                }
            }

            if (characterController.isGrounded)
            {
                isJump = false;
            }
        }
    }
}
