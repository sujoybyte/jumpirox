﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    private Transform[] bars;
    [SerializeField] private GameObject drop = null;
    private Color[] dropColors = {Color.red, Color.blue, Color.green};
    [SerializeField] private Transform dropStart = null;

    private void Awake()
    {
        // set the Transform component of each Bar to bars array
        bars = GameObject.Find("Bars").GetComponentsInChildren<Transform>();
        // calling DropMethod() after 1 second at start and then every 3 second
        InvokeRepeating("DropMethod", 1, 3);
    }

    // how a box drops from screen top
    private void DropMethod()
    {
        // generate random colored boxes at random positions
        GameObject dropCopy = Instantiate(drop, new Vector2(bars[Random.Range(1, 6)].position.x, dropStart.position.y), Quaternion.identity);
        // changing the color of drop copy to a random color
        dropCopy.GetComponent<SpriteRenderer>().color = dropColors[Random.Range(0, 3)];
    }
}

