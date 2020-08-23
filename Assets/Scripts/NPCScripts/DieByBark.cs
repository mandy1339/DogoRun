using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieByBark : MonoBehaviour
{
    private Collider2D thisCollider;
    private WalkOnPlatForm walkScript;
    private Rigidbody2D rb;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<Collider2D>();
        walkScript = GetComponent<WalkOnPlatForm>();
        //walkScript = this.gameObject.GetComponent<WalkOnPlatForm>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bark_tag"))
        {
            Die2();
        }
    }


    public void Die2()
    {
        thisCollider.enabled = false;
        if (walkScript != null)
        {
            walkScript.enabled = false;
        }
        // gameManager.PlayCatDie();
        rb.velocity = new Vector2(5f, 10f);
        rb.gravityScale = 4f;
        this.gameObject.GetComponent<SpriteRenderer>().flipY = true;
    }
}
