﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config params
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float runSpeed = 7f;
    [SerializeField] float jumpVelocity = 3f;
    [SerializeField] float extraRunSpeed = 0f;
    [SerializeField] public int health = 100;


    //cache
    Rigidbody2D myRigidbody;
    BoxCollider2D myFeet;
    Animator myAnimator;
    Transform myTransform;

    //GameObject hand;
    //GameObject sword;


    //states
    [SerializeField] bool isRunning = false;
    [SerializeField] bool isWalking = false;
    [SerializeField] bool isFacingRight = true;



    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        //hand = gameObject.transform.GetChild(0).gameObject;
        //sword = gameObject.transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        CheckDirection();
        Jump();
        Idle();
        Walk();
        Run();

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Idle()
    {
        if (!(Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon))
            
        {
            myAnimator.SetTrigger("Idling");
        }
    }

    private void Walk()
    {
        if ((Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift))
        {
            myAnimator.SetTrigger("Walking");
            float walkControlThrow = Input.GetAxis("Horizontal");
            float walkVelocity = walkControlThrow * walkSpeed;
            myRigidbody.velocity = new Vector2(walkVelocity, myRigidbody.velocity.y);
            
        }
    }

    private void Run()
    {
        if ((Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift))
        {
            myAnimator.SetTrigger("Running");
            float runControlThrow = Input.GetAxis("Horizontal");
            float runVelocity = runControlThrow * runSpeed;
            myRigidbody.velocity = new Vector2(runVelocity, myRigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground"))) { return; }
        if (Input.GetKeyDown(KeyCode.W))
        {
            myRigidbody.velocity += new Vector2(0, jumpVelocity);
        }
    }

    private void CheckDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //Debug.Log(mousePos.x);
        //Debug.Log(myTransform.position.x);

        if(mousePos.x > myTransform.position.x && !isFacingRight)
        {
            Debug.Log("Right");
            Flip();
        }
        else if(mousePos.x < myTransform.position.x && isFacingRight)
        {
            Debug.Log("Left");
            Flip();
        }

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = gameObject.transform.localScale;
        theScale.x *= -1;
        gameObject.transform.localScale = theScale;
        //if(theScale.x == -1)
        //{
            //hand.transform.localScale = theScale;
            //sword.transform.localScale = theScale;
        //}

    }
}
