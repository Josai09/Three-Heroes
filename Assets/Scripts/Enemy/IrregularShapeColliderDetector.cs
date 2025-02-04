using UnityEngine;
using System.Collections.Generic;

public class IrregularShapeColliderDetector : MonoBehaviour
{
    
    private CompositeCollider2D compositeCollider;
    private ContactFilter2D filter;
    private List<Collider2D> detectedObjects = new List<Collider2D>();

    

    void Start()
    {
        compositeCollider = GetComponent<CompositeCollider2D>();

        filter.useTriggers = false;

        BoxCollider2D[] circlecolliders = GetComponents<BoxCollider2D>();

        BoxCollider2D firstCollider = circlecolliders[0];  // First collider

        BoxCollider2D secondCollider = circlecolliders[1];

        BoxCollider2D thirdCollider = circlecolliders[2];

        if (firstCollider == null || secondCollider == null || thirdCollider == null){

            Debug.Log("Game Object doesn't have circle collider");

        }

    }

    void Update()
    {
        DetectObjectsInsideAOE();

        DetectObjectsCircleAOE();

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

        Vector2 radius = transform.position;

        //comment

        
    }
}