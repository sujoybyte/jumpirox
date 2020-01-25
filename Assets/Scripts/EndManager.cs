using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class EndManager : MonoBehaviour
{
    public GameObject hero ;
    public Transform endStart ;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject == hero)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
        }
    }
}
