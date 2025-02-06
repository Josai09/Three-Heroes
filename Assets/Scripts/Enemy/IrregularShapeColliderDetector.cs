using UnityEngine;
using System.Collections.Generic;

public class IrregularShapeColliderDetector : MonoBehaviour
{
    
    private CompositeCollider2D compositeCollider;
    private ContactFilter2D filter;
    private List<Collider2D> detectedObjects = new List<Collider2D>();
    private CircleCollider2D[] circlecolliders;
    private ContactFilter2D filtercircle;

    

    void Start()
    {
        compositeCollider = GetComponent<CompositeCollider2D>();

        filter.useTriggers = false;

        circlecolliders = GetComponents<CircleCollider2D>();

        if(circlecolliders == null){

            Debug.Log("Object doesn't have circle collider");

        }

        filtercircle.useTriggers = false;

        
    }

    void Update()
    {
        DetectObjectsInsideAOE();

        if(circlecolliders != null){

            DetectObjectsCircleAOE();

        }

        

    }

    void DetectObjectsInsideAOE()
    {
        detectedObjects.Clear();

        Collider2D[] results = new Collider2D[10]; // Adjust size if needed

        int count = compositeCollider.OverlapCollider(filter, results);

        for (int i = 0; i < count; i++){

            if (results[i] != null)

            {
                detectedObjects.Add(results[i]);
                
                Debug.Log(this.gameObject.name + "Detected: " + results[i].gameObject.name);

            }
        }
    }

    void DetectObjectsCircleAOE(){

        foreach (CircleCollider2D collider in circlecolliders){

            List<Collider2D> detectedobjects = new List<Collider2D>();

            collider.OverlapCollider(filtercircle,detectedobjects);

            foreach (Collider2D col in detectedobjects){

                Debug.Log(this.gameObject.name + "detected " + col.gameObject.name);

            }





        }


        
    }
}