using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailRun : MonoBehaviour
{
    CharacterController myCharacterController;

    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 4f;

    private const float gravity = 25f;

    Vector3 moving;

    private void Start()
    {

    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (myCharacterController.isGrounded)
        {
            moving = new Vector3(Input.GetAxis("Hotizontal"), 0f, Input.GetAxis("Vertical"));
            moving *= speed;
            if (Input.GetButton("Jump"))
            {
                moving.y = jump;
            }
        }
        moving.y -= gravity * Time.deltaTime;

        myCharacterController.Move(moving * Time.deltaTime);
    }
}
