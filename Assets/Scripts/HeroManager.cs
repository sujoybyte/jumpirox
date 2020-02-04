using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement ;

public class HeroManager : MonoBehaviour
{
    Rigidbody2D heroRigidbody2d ;
    public SpriteRenderer heroEye ;
    public SpriteRenderer heroTop ;
    //bool isFliped = false ;
    public float moveSpeed = 150f ;
    public Color heroColor ;
    GameObject score ;

    void Awake()
    {
        // set the Hero's Rigidbody2D component
        heroRigidbody2d = transform.GetComponent<Rigidbody2D>() ;
        score = GameObject.FindGameObjectWithTag("Score") ;
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
        {
            if (Input.GetKeyDown("left"))
                FlipHero(true) ;
            if (Input.GetKeyDown("right"))
                FlipHero(false) ;
            heroRigidbody2d.velocity = new Vector2(moveInput, Mathf.Abs(moveInput)) * Time.deltaTime * moveSpeed ;
        }
        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            heroRigidbody2d.velocity = new Vector2(moveInput / 2, Mathf.Abs(moveInput) / 2) * Time.deltaTime * moveSpeed ;
        }
        
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

    void FlipHero(bool value)
    {
        heroEye.flipX = value ;
        heroTop.flipX = value ;
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Box")
        {
            if (!other.gameObject.GetComponent<SpriteRenderer>().enabled)
                ScoreChange(1) ;
        }
        if (other.gameObject.tag == "Bar")
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().color == other.gameObject.GetComponent<SpriteRenderer>().color)
            {
                
                if (this.gameObject.GetComponent<SpriteRenderer>().color != Color.black)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.black ;
                    other.gameObject.GetComponent<SpriteRenderer>().color = Color.black ;
                    ScoreChange(3) ;
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
            }
        }
    }

    public void ScoreChange(int add)
    {
        string scoreText = score.GetComponent<Text>().text ;
        score.GetComponent<Text>().text = System.Convert.ToString(int.Parse(scoreText) + add) ;
        Debug.Log(score.GetComponent<Text>().text) ;
    }
}
