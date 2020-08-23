using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenjiLose : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameManager gm;
    private BenjiSounds benjiSounds;
    private bool benjiLost = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        benjiSounds = GetComponent<BenjiSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -4.77f)
        {
            if (!benjiLost)
            {
                benjiLost = true;
                GameManager.isGameOver = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
