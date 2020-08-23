using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private GameObject gmObject;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gm = gmObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("benji_tag"))
        {
            gm.ClearLevel();
        }
    }

    /*  private void OnTriggerEnter2D(Collider other)
      {
          
      }*/
}
