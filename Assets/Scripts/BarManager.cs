using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    private float yStartPosition, yEndPosition;
    private Vector2 screenSize;
    private bool isGoingUp;
    [SerializeField] private float barSpeed = 0.5f;

    private void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) * 2;
        yStartPosition = transform.position.y;
        yEndPosition = yStartPosition + screenSize.y / 16;
    }

    private void Update()
    {
        RandomUpDown();
    }

    private void RandomUpDown()
    {
        float minRange = yStartPosition + screenSize.y / 32;

        // checking for if the Bar goes up or down
        if (isGoingUp) transform.Translate(new Vector2(0, 1) * Time.deltaTime * barSpeed);
        if (!isGoingUp) transform.Translate(new Vector2(0, -1) * Time.deltaTime * barSpeed);

        // checking for random end position and when less then start
        if (transform.position.y >= Random.Range(minRange, yEndPosition)) isGoingUp = false;
        if (transform.position.y <= yStartPosition) isGoingUp = true;
    }
}
