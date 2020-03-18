using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Color boxColor;

    void Start()
    {
        // set the color of the created box
        boxColor = GetComponent<SpriteRenderer>().color;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // chechking for objects with tag 'Bar' and 'Hero'
        if (other.gameObject.tag == "Bar" || other.gameObject.tag == "Hero")
        {
            // set the collided object's color to the color of the box
            other.gameObject.GetComponent<SpriteRenderer>().color = boxColor;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            // removing the box object
            Destroy(this.gameObject);
        }
    }
}

