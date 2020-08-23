using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour ,IEnemy
{
    [SerializeField] private GameObject _starParticleEffect;
    private AudioSource[] catSounds;
    private AudioSource catDie;
    private GameObject gameManagerObject;
    private GameManager gm;
    private BoxCollider2D thisCollider;
    private WalkOnPlatForm walkScript;
    private Rigidbody2D rb;
    private SpriteRenderer catSpriteRender;
    public float bounceForceOnDeath;
    public float scaleOfStarParticleEffect;


    // Start is called before the first frame update
    void Start()
    {
        catSounds = GetComponents<AudioSource>();
        catDie = catSounds[0];
        gameManagerObject = GameObject.Find("GameManager");
        gm = gameManagerObject.GetComponent<GameManager>();
        thisCollider = GetComponent<BoxCollider2D>();
        walkScript = GetComponent<WalkOnPlatForm>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        catSpriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCatDie()
    {
        catDie.Play();
    }

    public void Die()
    {
        PlayCatDie();
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("benji_tag"))
        {
            if (other.transform.position.y - other.collider.bounds.extents.y < this.transform.position.y)
            {
                GameManager.isGameOver = true;
            }
            else
            {
                ThisEnemyDies();
                // benji bounces
                Vector3 benjiVelocity = other.gameObject.GetComponent<Rigidbody2D>().velocity;
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(benjiVelocity.x, bounceForceOnDeath, benjiVelocity.z);
            }
        }
    }


    private void ThisEnemyDies()
    {
        // play star particle effect here
        float halfHeightOfCatSprite = catSpriteRender.bounds.size.y / 2;
        GameObject starParticleEffect = Instantiate(_starParticleEffect, transform.position + Vector3.up * halfHeightOfCatSprite ,Quaternion.identity);
        starParticleEffect.transform.localScale = new Vector2(scaleOfStarParticleEffect, scaleOfStarParticleEffect);

        gm.PlayCatDie();
        thisCollider.enabled = false;
        if (walkScript != null)
        {
            walkScript.enabled = false;
        }
        // gameManager.PlayCatDie();
        //rb.velocity = new Vector2(5f, 10f);
        //rb.gravityScale = 4f;
        this.transform.localScale = new Vector3(this.transform.localScale.x, 0.25f * this.transform.localScale.y, this.transform.localScale.z);


        //this.PlayCatDie();
        //Destroy(this.gameObject);
    }

    private void OnBecameInvisible()
    {
        //Destroy(this.gameObject);
        this.gameObject.GetComponent<Cat>().enabled = false;
            
    }
}
