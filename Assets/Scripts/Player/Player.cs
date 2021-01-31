﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float horizontalAxis;
    private float verticalAxis;
    public float movSpeed = 5f;
    private Rigidbody2D rigidBody;
    Animator anim;
    private bool lateral = false, espalda = false, frente = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        if (horizontalAxis > 0)
        {
            //gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
            //anim.SetBool("Espalda", false);
            //anim.SetBool("Frente"  ,false);
            anim.SetBool("Lateral", true);
            anim.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        }
        else if (horizontalAxis < 0)
        {
            //gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            //anim.SetBool("Frente", false);
            //anim.SetBool("Espalda", false);
            anim.SetBool("Lateral", true);
            anim.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        }
        else if (verticalAxis > 0)
        {
            //gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //anim.SetBool("Lateral", false);          
            //anim.SetBool("Frente", false);
            anim.SetBool("Espalda", true);
            anim.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.y));
        }
        else if (verticalAxis < 0)
        {
            //gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //anim.SetBool("Lateral", false);
            //anim.SetBool("Espalda", false);
            anim.SetBool("Frente", true);
            anim.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.y));
        }
        else
        {
            anim.SetBool("Frente", false);
            anim.SetBool("Espalda", false);
            anim.SetBool("Lateral", false);
            rigidBody.velocity = new Vector2(horizontalAxis * movSpeed, verticalAxis * movSpeed);
            anim.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        }


    }

    private void FixedUpdate()
    {
        Physics2D.gravity = Vector2.zero;
        rigidBody.gravityScale = 0.0f;
        rigidBody.velocity = new Vector2(horizontalAxis * movSpeed, verticalAxis * movSpeed);

    }

   

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Door"))
        {
            GameManager.Instance.ShowDoorMessage(collision.collider, true);


            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.InteractWithDoor(collision.collider);
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            GameManager.Instance.ShowDoorMessage(collision.collider, false);
        }
    }

}