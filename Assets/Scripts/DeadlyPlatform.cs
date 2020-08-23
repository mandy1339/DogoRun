using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyPlatform : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // avoid dying by having your bottom trigger collider hit the deadly hitbox of the platform
        if ((other.transform.position.y - 0.75f > this.transform.position.y))
        {

        }
        else
        {
            if (other.CompareTag("benji_tag"))
            {
                GameManager.isGameOver = true;
            }
        }
            
        
    }

}
