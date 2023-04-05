using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float height;

    private void Awake()
    {
        height = transform.GetComponent<BoxCollider2D>().size.y;
        //Debug.Log(transform.) 12.8
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -height)
        {
            Reposition();
        }
    }

    //배경 뒤로 가는 매서드
    public void Reposition() 
    {
        Vector2 offset = new Vector2(0, height * 2);
        transform.position = (Vector2)transform.position + offset;
    }
}
