using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeryDeadlyContact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("benji_tag"))
        {
            GameManager.isGameOver = true;
        }
    }
}
