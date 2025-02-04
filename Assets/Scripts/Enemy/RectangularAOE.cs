using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RectangularAOE : MonoBehaviour
{
    CompositeCollider2D colliderAOE;

    [SerializeField]
    float cobamin;

    [SerializeField]
    float cobamax;
    // Start is called before the first frame update
    void Start()
    {
        
        colliderAOE = GetComponent<CompositeCollider2D>();

    }


    // Update is called once per frame
    public  void Update()
    {

        DetectedObject();
       
    }

    void DetectedObject(){

        Collider2D[] hitsArea = Physics2D.OverlapAreaAll(colliderAOE.bounds.min * cobamin , colliderAOE.bounds.max * cobamax);
        
        foreach (Collider2D hit in hitsArea)
        {

            Debug.Log(this.gameObject.name + "AOE (Area) detected: " + hit.gameObject.name);

        }

    }
}
