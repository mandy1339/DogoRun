using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyContact : MonoBehaviour
{
    private BoxCollider2D thisCollider;


    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
        }
    }


    private void ThisEnemyDies()
    {
        // thisCollider.enabled = false;
        Destroy(this.gameObject);

    }
}
