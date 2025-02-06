using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag == "Heroes"){

            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();

            if(rb != null){

                rb.gravityScale = 100;

            }

        }


    }
}
