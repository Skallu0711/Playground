using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OPCJA Z PARENTINGIEM JEST FAJNIEJSZA IMO XD

public class RigidbodyCarry : MonoBehaviour
{
    public List<Rigidbody2D> rigidbodyies2D = new List<Rigidbody2D>();

    public Vector3 lastPosition;

    void Start()
    {    
        lastPosition = transform.position;
    }

    private void Update()
    {
        // if the list contains rigidbody2D, we move rigidbody2D according to the speed of the platform
        if (rigidbodyies2D.Count == 1)
        {
            Rigidbody2D rigidbody2D = rigidbodyies2D[0];
            
            Vector3 speed = (transform.position - lastPosition);
            rigidbody2D.transform.Translate(speed, transform);
        }

        lastPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {    
        // attach rigidbody2D to the collider object and when rigidbody2D is not null, whe know there is something touching the platform, so we add rigidbody to the carrier list if it's not contained
        Rigidbody2D rigidbody2D = collision2D.collider.GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            if (!rigidbodyies2D.Contains(rigidbody2D))
            {
                rigidbodyies2D.Add(rigidbody2D);
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision2D)
    {    
        // if there is rigidbody2D touching the platform and the list contains if, we remove it from the list
        Rigidbody2D rigidbody2D = collision2D.collider.GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            if (rigidbodyies2D.Contains(rigidbody2D))
            {
                rigidbodyies2D.Remove(rigidbody2D);
            }
        }
    }
    
}
