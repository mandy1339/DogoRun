using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScriptFollow : MonoBehaviour
{
    public GameObject cam;

    
    public GameObject dogo;
    private SpriteRenderer spriteRenderer;
    //private Sprite sprite;
    private float rightSidePos;
    private float rectLength;

    private void Start()
    {
        //sprite = spriteRenderer.sprite;
        //rightSidePos = sprite.rect.xMax;
        //rectLength = sprite.rect.width;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rectLength = spriteRenderer.bounds.size.x;// * transform.localScale.x;
        rightSidePos = (spriteRenderer.bounds.size.x) / 2 + this.transform.position.x;
    }


    private void LateUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x, cam.transform.position.y, 0);
        if (dogo.transform.position.x >= rightSidePos + 3)
        {
            this.transform.position += Vector3.right * rectLength * 2;
            rightSidePos = spriteRenderer.bounds.size.x / 2 + this.transform.position.x;
        }
    }

/*    private void LateUpdate()
    {
        this.transform.position = (Vector2)cam.transform.position;
    }
*/











}
