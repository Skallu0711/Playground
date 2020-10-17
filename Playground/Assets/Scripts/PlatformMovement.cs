using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private float speed = 1.0f;

    private bool isMovingRight = true;

    void Update()
    {
        if (transform.position.x > 7.0f)
        {
            isMovingRight = false;
        }

        if (transform.position.x < -0.63f)
        {
            isMovingRight = true;
        }

        if (isMovingRight == true)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        
    }
}
