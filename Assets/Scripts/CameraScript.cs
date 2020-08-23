using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject dogo;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        if(dogo.transform.position.y > 1)
        {
            this.transform.position = new Vector3(dogo.transform.position.x + 7.415f, dogo.transform.position.y -1, -10);
        }
        else
        {
            this.transform.position = new Vector3(dogo.transform.position.x + 7.415f, 0, -10);
        }
        
    }
}
