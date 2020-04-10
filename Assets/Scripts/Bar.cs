using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    private Vector2 barStartPosition, barEndPosition;
    private Vector2 screenSize;
    private bool isGoingUp = true;
    private float speed = 0.5f;

    private void Start()
    {
        // set the bar's initial position at start
        barStartPosition = transform.position;
        // set the screen size in local unit from pixel unit
        screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) * 2;
    }

    private void Update()
    {
        AutoUpDown();
    }

    // move the Bar up and down continuously with random value
    private void AutoUpDown()
    {
        // the position at which the Bar gets bounced back
        barEndPosition.y = barStartPosition.y + screenSize.y / 16;
        // checking for if the Bar goes up
        if (isGoingUp)
            transform.Translate(new Vector2(0, 1) * Time.deltaTime * speed);
        // checking for if the Bar goes down
        if (!isGoingUp)
            transform.Translate(new Vector2(0, -1) * Time.deltaTime * speed);
        // checking for random end position
        if (transform.position.y >= Random.Range(barStartPosition.y + screenSize.y / 32, barEndPosition.y))
            isGoingUp = false;
        if (transform.position.y <= barStartPosition.y)
            isGoingUp = true;
    }
}

