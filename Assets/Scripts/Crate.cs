using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    //private EdgeCollider2D[] edges;
    private EdgeCollider2D safeEdge;
    //private EdgeCollider2D deadlyEdge;
    private void Start()
    {
        safeEdge = GetComponent<EdgeCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

}
