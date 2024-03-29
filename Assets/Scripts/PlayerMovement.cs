﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Animator myAnimator;

    Vector3 moveDirectionPush;

    [SerializeField] float moveSpeed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();

        rb.freezeRotation = true; //prevents charcter from rotating 
    }

    void Update()
    {
        Run();
        Rotation();
    }

    void Run()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue, 0, zValue);

        if(xValue != 0 || zValue != 0)
        {
            myAnimator.SetTrigger("Run");
            myAnimator.ResetTrigger("Idle");
        }
        else
        {
            myAnimator.SetTrigger("Idle");
            myAnimator.ResetTrigger("Run");
        }
    }

    void Rotation()
    {
        transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X") * 1f, 0)); //mouse follow 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Car")
        {
            moveDirectionPush = rb.transform.position - collision.transform.position; //knockback effect 
            rb.AddForce(moveDirectionPush.normalized * 750f); //knockback effect 
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.freezeRotation = true;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.freezeRotation = true;
        }
    }
}
