using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField] private GameObject hero = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == hero)
        {
            // Restart game - restart scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

