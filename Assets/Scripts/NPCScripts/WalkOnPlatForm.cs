using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOnPlatForm : MonoBehaviour
{
    private float initialXPosition;
    public bool walkLeftOnStart;
    public float walkingSpeed;
    private bool walkingLeft;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        initialXPosition = this.transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if (walkLeftOnStart)
        {
            walkingLeft = true;
            rb.velocity = new Vector2(-walkingSpeed, 0);
        }
        else
        {
            walkingLeft = false;
            rb.velocity = new Vector2(walkingSpeed, 0);
        }
            

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isVisible)
        {
            if (walkingLeft)
            {
                //rb.AddForce(Vector2.left * walkingSpeed * Time.deltaTime, ForceMode2D.Impulse);
                rb.velocity = new Vector2(-walkingSpeed, rb.velocity.y);
            }
            else
            {
                //rb.AddForce(Vector2.right * walkingSpeed * Time.deltaTime, ForceMode2D.Impulse);
                rb.velocity = new Vector2(walkingSpeed, rb.velocity.y);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.collider.CompareTag("ground_tag") && !collision.collider.CompareTag("slidy_edge_tag"))
        {
            if (walkingLeft)
            {
                rb.velocity = new Vector2(-walkingSpeed, rb.velocity.y);
                walkingLeft = false;
                sr.flipX = true;
            }

            else
            {
                rb.velocity = new Vector2(walkingSpeed, rb.velocity.y);
                walkingLeft = true;
                sr.flipX = false;
            }
                
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("platform_edge_tag"))
        {
            if (walkingLeft)
            {
                walkingLeft = false;
                sr.flipX = true;
            }
                
            else
            {
                walkingLeft = true;
                sr.flipX = false;
            }
                
        }
    }

    private void OnBecameVisible()
    {
        isVisible = true;
        GetComponent<Cat>().enabled = true;
    }
}
