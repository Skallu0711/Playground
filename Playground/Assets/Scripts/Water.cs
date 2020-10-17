using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
