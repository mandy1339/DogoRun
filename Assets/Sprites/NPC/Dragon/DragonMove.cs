using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float dragonSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // rb.AddForce(Vector2.right * dragonSpeed, ForceMode2D.Impulse);
        //rb.velocity = Vector2.right * dragonSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * dragonSpeed;
        //this.transform.Translate(Vector2.right * dragonSpeed * Time.deltaTime);
    }
}
