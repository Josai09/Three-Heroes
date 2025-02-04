using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    CompositeCollider2D colliderAOE;
    Collider2D[] results = new Collider2D[10]; // Array to store results
    ContactFilter2D filter; // Used to filter the results

    Collider2D[] collidersInside;

    [SerializeField]
    float coba = 0;

    // Start is called before the first frame update
    void Start()
    {

        colliderAOE = GetComponent<CompositeCollider2D>();
        
        filter = new ContactFilter2D();

        filter.NoFilter();

        filter.useTriggers = false;

        filter.SetLayerMask(Physics2D.AllLayers);


        
        //get collider inside
        //collidersInside = Physics2D.OverlapBoxAll(colliderAOE.bounds.center, colliderAOE.bounds.extents,0f);  
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("heyo");
        ///////////////
        //ovelap(buggy)
        /*int count = colliderAOE.OverlapCollider(filter, results);

        Debug.Log("Number of objects inside AOE: " + count); // Helps debug


        for (int i = 0; i < count; i++){

            if (results[i].CompareTag("Heroes")) // Ensure Object B has this tag
            {
                Debug.Log(results[i].gameObject.name + "is inside AOE");
            }
        }*/


        //Collider2D[] debugResults = Physics2D.OverlapAreaAll(colliderAOE.bounds.min, colliderAOE.bounds.max);
        //Debug.Log("OverlapAreaAll Count: " + debugResults.Length);
        
        /*foreach (Collider2D col in collidersInside)
        {
            if (col.gameObject != gameObject) // Exclude itself
            {
                Debug.Log(col.gameObject.name + " is inside Object AOE");
            }
        }*/

        //////////////////
        //AOEworks
        Vector2 aoeCenter = transform.position;

        float aoeRadius = colliderAOE.bounds.extents.magnitude * coba;
        //aoeradiuscircle 0.95,position 0.7


        Collider2D[] hits = Physics2D.OverlapCircleAll(aoeCenter, aoeRadius);

        foreach (Collider2D hit in hits)
        {
            if(hit.tag == "Heroes"){

                Debug.Log("AOE (Circle) detected: " + hit.gameObject.name);
        }

        }
        ///////////////////
            

    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Heroes"){

            Debug.Log(other.name + "inside AOE");
        }
        
    }*/

}
