using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 200.0f;
    public float sprintForce = 350.0f;
    public float jumpForce = 300.0f;
    public float dashForce = 75.0f;
    
    private bool isGrounded;
    private bool isFacingRight;
    
    private Rigidbody2D rigidbody2D;
    
    void Start()
    {
        Debug.Log("Start");
        
        rigidbody2D = GetComponent<Rigidbody2D>();

        isGrounded = true;
        isFacingRight = true;
    }
    
    void Update()
    {    
        // horizontal movement with sprint when shift is held
        float movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
        {
            rigidbody2D.velocity = new Vector2(movement * sprintForce * Time.deltaTime, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(movement * speed * Time.deltaTime, rigidbody2D.velocity.y);
        }
        
        // dash
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isFacingRight == true)
            {
                rigidbody2D.velocity = new Vector2( dashForce, rigidbody2D.velocity.y);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(-dashForce, rigidbody2D.velocity.y);
            }
        }
        
        // check if character is moving left or right, so we can flip his sprite
        if (isFacingRight && movement < 0)
        {
            Flip();
        } 
        else if (!isFacingRight && movement > 0)
        {
            Flip();
        }
        
        // jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }

        // dive down in midair
        if (Input.GetKeyDown(KeyCode.S))
        {
            rigidbody2D.AddForce(new Vector2(0, -(2*speed)));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        isGrounded = true;
    }
    
    // flips character's sprite
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

}
