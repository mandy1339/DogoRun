using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyCrateEdge : MonoBehaviour
{
    private EdgeCollider2D deadlyEdge;
    // Start is called before the first frame update
    void Start()
    {
        deadlyEdge = GetComponent<EdgeCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("benji_tag"))
        {
            GameManager.isGameOver = true;
        }
    }
}
