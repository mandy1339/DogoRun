using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkScript : MonoBehaviour
{
    public float barkSpeed;
    public float growRate;
    public float initialXPos = -1;


    // Start is called before the first frame update
    void Start()
    {

    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(initialXPos != -1 && this.transform.position.x > initialXPos + 31f)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    this.transform.Translate(Vector3.right * barkSpeed * Time.deltaTime);
        //    this.transform.localScale += new Vector3(growRate * Time.deltaTime, growRate * Time.deltaTime);
        //}
        this.transform.Translate(Vector3.right * barkSpeed * Time.deltaTime);
        this.transform.localScale += new Vector3(growRate * Time.deltaTime, growRate * Time.deltaTime);

    }


    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

}
