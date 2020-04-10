using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroManager : MonoBehaviour
{
    private Rigidbody2D heroRigidbody2d;
    [SerializeField] private SpriteRenderer heroEye = null, heroTop = null;
    [SerializeField] private float moveSpeed = 150f;
    private GameObject score;

    private void Awake()
    {
        // set the Hero's Rigidbody2D component
        heroRigidbody2d = transform.GetComponent<Rigidbody2D>();
        score = GameObject.FindGameObjectWithTag("Score");
    }

    private void Update()
    {
        Movement();
    }

    // jump movement control for Hero
    private void Movement()
    {
        // KEYBOARD CONTROL
        float moveInput = Input.GetAxisRaw("Horizontal");
        // if presses the left or right arrow keys
        if (Input.GetKeyDown("left") || Input.GetKeyDown("right"))
        {
            if (Input.GetKeyDown("left"))
                FlipHero(true);
            if (Input.GetKeyDown("right"))
                FlipHero(false);
            heroRigidbody2d.velocity = new Vector2(moveInput, Mathf.Abs(moveInput)) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            heroRigidbody2d.velocity = new Vector2(moveInput / 2, Mathf.Abs(moveInput) / 2) * Time.deltaTime * moveSpeed;
        } 

        // TOUCH CONTROL
        if (Input.touchCount > 0)
        {
            // getting the first tap and it's local position on screen
            Touch screenTap = Input.GetTouch(0);
            Vector2 tapPosition = Camera.main.ScreenToWorldPoint(screenTap.position);
            // if touches the right bottom area
            if (tapPosition.x > 0 && tapPosition.y < 0)
                heroRigidbody2d.velocity = new Vector2(1.0f, 1.0f) * Time.deltaTime * moveSpeed;
            // if touches the left bottom area
            if (tapPosition.x < 0 && tapPosition.y < 0)
                heroRigidbody2d.velocity = new Vector2(-1.0f, 1.0f) * Time.deltaTime * moveSpeed;
        }
    }

    // flipping the hero
    private void FlipHero(bool value)
    {
        // flipping hero eye top gear
        heroEye.flipX = value;
        heroTop.flipX = value;
    }

    private void OnCollisionExit2D(Collision2D collided) 
    {
        // checking for the object box
        if (collided.gameObject.tag == "Box")
        {
            // checking if the sprite renderer component is inactive and increase the score
            if (!collided.gameObject.GetComponent<SpriteRenderer>().enabled)
                ScoreChange(1);
        }
        // checking for the object bar
        if (collided.gameObject.tag == "Bar")
        {
            Color heroColor = this.gameObject.GetComponent<SpriteRenderer>().color;
            Color collidedColor = collided.gameObject.GetComponent<SpriteRenderer>().color;
            // checking if hero collided with an object of same color
            if (heroColor == collidedColor)
            {
                // checking if hero color is not black
                if (heroColor != Color.black)
                {
                    // making hero and it's collided object black
                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                    collided.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                    // increase score with bonus score
                    ScoreChange(5);
                }
            }
            else
            {
                // restarting level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    // changing the score
    private void ScoreChange(int add)
    {
        // converting the score value and calculte
        string scoreText = score.GetComponent<Text>().text;
        score.GetComponent<Text>().text = System.Convert.ToString(int.Parse(scoreText) + add);
    }
}

