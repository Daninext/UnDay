using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall_Sc : MonoBehaviour
{
    public bool Enter;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
            Enter = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        }
    }
}
