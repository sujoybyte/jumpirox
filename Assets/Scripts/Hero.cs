using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    Rigidbody2D heroRigidbody2d ;
    public float moveSpeed = 150f ;

    void Awake()
    {
        // set the Hero's Rigidbody2D component
        heroRigidbody2d = transform.GetComponent<Rigidbody2D>() ;
    }

    void Update()
    {
        Movement() ;
    }

    // jump movement control for Hero
    void Movement()
    {
        // KEYBOARD CONTROL
        float moveInput = Input.GetAxisRaw("Horizontal") ;
        // if presses the left or right arrow keys
        if (Input.GetKeyDown("left") || Input.GetKeyDown("right"))
            heroRigidbody2d.velocity = new Vector2(moveInput, Mathf.Abs(moveInput)) * Time.deltaTime * moveSpeed ;
        if (Input.GetKey("left") || Input.GetKey("right"))
            heroRigidbody2d.velocity = new Vector2(moveInput / 2, Mathf.Abs(moveInput) / 2) * Time.deltaTime * moveSpeed ;
        
        // TOUCH CONTROL
        if (Input.touchCount > 0)
        {
            // getting the first tap and it's local position on screen
            Touch screenTap = Input.GetTouch(0) ;
            Vector2 tapPosition = Camera.main.ScreenToWorldPoint(screenTap.position) ;
            // if touches the right bottom area
            if (tapPosition.x > 0 && tapPosition.y < 0)
                heroRigidbody2d.velocity = new Vector2(1.0f, 1.0f) * Time.deltaTime * moveSpeed ;
            // if touches the left bottom area
            if (tapPosition.x < 0 && tapPosition.y < 0)
                heroRigidbody2d.velocity = new Vector2(-1.0f, 1.0f) * Time.deltaTime * moveSpeed ;
        }
    }
}
