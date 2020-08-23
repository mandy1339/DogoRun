using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BenjiControls : MonoBehaviour
{
    [SerializeField] private GameObject _dustParticlesPrefab;
    private Rigidbody2D rb;
    public float jumpStrength = 8;
    public float shortJumpDownStrength = 2;
    public float fallStrength = 3;
    bool canJump = true;
    private Animator anim;
    public float dogoSpeed;
    static LayerMask groundMask;
    public BoxCollider2D groundCheckCollider;
    private BenjiSounds benjiSounds;
    private bool justLanded = false;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundMask = LayerMask.NameToLayer("ground");
        benjiSounds = GetComponent<BenjiSounds>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

// Update is called once per frame

private void Update()
    {
        canJump = IsGrounded();
        rb.velocity = new Vector2(dogoSpeed, rb.velocity.y);

        if (!IsPointerOverUIObject())//IsPointerOverGameObject())
        {       
            if (Input.GetMouseButtonDown(0) && canJump)
            {
                rb.velocity = Vector2.up * jumpStrength;
                benjiSounds.PlayJump();
            }
        }

        

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 6;
        }

        if (rb.velocity.y == 0)
        {
            rb.gravityScale = 1;
        }
        if (rb.velocity.y > 0)
        {
            if (Input.GetMouseButton(0))
            {
                rb.gravityScale = 1;
            }
            else
            {
                rb.gravityScale = shortJumpDownStrength;
            }
        }



        // Jumping Animation
        if (canJump == false)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

    }

    void FixedUpdate()
    {
        /*canJump = IsGrounded();
        rb.velocity = new Vector2(dogoSpeed, rb.velocity.y);

        if(Input.GetMouseButtonDown(0) && canJump)
        {
            rb.velocity = Vector2.up * jumpStrength;
            benjiSounds.PlayJump();
        }*/

        //
        rb.velocity = new Vector2(dogoSpeed, rb.velocity.y);

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 6;
        }
        
        if(rb.velocity.y == 0)
        {
            rb.gravityScale = 1;
        }
        if (rb.velocity.y > 0)
        {
            if (Input.GetMouseButton(0))
            {
                rb.gravityScale = 1;
            }
            else
            {
                rb.gravityScale = shortJumpDownStrength;
            }
        }



        // Jumping Animation
        if (canJump == false)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }



        //Debug.DrawRay(this.transform.position, Vector3.down* 0.7529f);

        //jump through platform when going up
        if (!canJump && rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(9, 12, true);
        }
        //else the collision will not be ignored
        else
        {
            Physics2D.IgnoreLayerCollision(9, 12, false);
        }

    }

   

    // Grounding logic
    private void OnTriggerExit2D(Collider2D collision)
    {
/*        if (collision.gameObject.layer == groundMask)
        {
            canJump = false;
        }*/
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
/*        if (collision.gameObject.layer == groundMask)
        {
            canJump = true;
        }*/
    }


    private bool IsGrounded()
    {
        // RaycastHit2D boxCastHit = Physics2D.BoxCast(new Vector2(this.transform.position.x - .10735f, this.transform.position.y + .081684f-1.0746f-.13f), new Vector2(2.51f, 0.229f), 0f, Vector2.down,1.0f);
        // groundCheckCollider.bounds.extents.y;
        // groundCheckCollider.bounds.extents.x;
        RaycastHit2D[] boxCastHit = Physics2D.BoxCastAll(groundCheckCollider.bounds.center, new Vector2(groundCheckCollider.bounds.extents.x + .83f,groundCheckCollider.bounds.extents.y), 0f, Vector2.down, groundCheckCollider.bounds.extents.y -.03f);
        foreach(RaycastHit2D collider in boxCastHit)
        {
            if (!(collider.collider.CompareTag("benji_tag")) && !collider.collider.CompareTag("platform_edge_tag"))
            {
                //print("HITTING GROUND ---------------------->");
                if (justLanded != true)
                {
                    justLanded = true;
                    benjiSounds.PlayLand();
                    Instantiate(_dustParticlesPrefab, transform.position + new Vector3(-.2f, -spriteRenderer.bounds.size.y / 2, 0), Quaternion.identity); 
                }
                return true;
            }
        }
        //Debug.DrawRay(new Vector2(-8.4f, -4.21f), Vector2.left * 2.71f, Color.red);
        //Debug.DrawRay(new Vector2(-8.4f, -4.21f), Vector2.right * 34.39f, Color.red);
        //print(groundCheckCollider.bounds.center);
        //Physics2D.BoxCast()
        //Debug.DrawRay(new Vector2(this.transform.position.x  , this.transform.position.y + .081684f - 1.0746f), new Vector2(0, -0.114f));
        //Debug.DrawRay()

        justLanded = false;
        return false;
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


}
