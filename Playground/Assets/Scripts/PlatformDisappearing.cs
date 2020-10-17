using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDisappearing : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        StartCoroutine(WaitAndDestroy(1.0f));
    }

    private IEnumerator WaitAndDestroy(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        Destroy(this.gameObject);
        Debug.Log("INFO: Object: " + this.gameObject.name + " destroyed");
    }

    
}
