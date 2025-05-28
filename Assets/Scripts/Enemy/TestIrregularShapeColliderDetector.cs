using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIrregularShapeColliderDetector : MonoBehaviour
{
    // Start is called before the first frame update

    private HashSet<GameObject> alreadyDamaged = new HashSet<GameObject>();

    //private CompositeCollider2D compositeCollider;

    private ContactFilter2D filter;

    private CircleCollider2D[] circleColliders;

    private ContactFilter2D filtercircle;

    Health _healthscript;

    //int _damage = 0;
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


public void ResetDamageState()
{
    alreadyDamaged.Clear();
    
}

public void DetectObjectsInsideAOE()
{
    ///////heyo
    /*if(compositeCollider != null){

        compositeCollider = GetComponentInChildren<CompositeCollider2D>();

        Collider2D[] results = new Collider2D[10];

        int count = compositeCollider.OverlapCollider(filter, results);

        for (int i = 0; i < count; i++)
        {
            if (results[i] != null)
            {
                GameObject obj = results[i].gameObject;

                if (!alreadyDamaged.Contains(obj))
                {
                    alreadyDamaged.Add(obj);

                    Debug.Log(this.gameObject.name + " (Composite) detected: " + obj.name);
                    _damage++;

                    // obj.GetComponent<Health>()?.Damage();
                }
            }
        }

}*/

        CompositeCollider2D[] compositeColliders = GetComponentsInChildren<CompositeCollider2D>();

        foreach (var composite in compositeColliders)
        {
            Collider2D[] results = new Collider2D[10];
            int count = composite.OverlapCollider(filter, results);

            for (int i = 0; i < count; i++)
            {
                if (results[i] != null)
                {
                    GameObject obj = results[i].gameObject;

                    if (!alreadyDamaged.Contains(obj))
                    {
                        alreadyDamaged.Add(obj);

                        Debug.Log(this.gameObject.name + " (Composite) detected: " + obj.name);

                        //_damage++;
                        Health health = obj.GetComponent<Health>();

                        if (health != null){

                        health.Damage();

                        }
                        
                    }
                }
            }
        }
    
    
}

public void DetectObjectsCircleAOE()
{
    circleColliders = GetComponentsInChildren<CircleCollider2D>();

    if(circleColliders != null){

        foreach (CircleCollider2D collider in circleColliders)
        {
            List<Collider2D> detectedobjects = new List<Collider2D>();

            collider.OverlapCollider(filtercircle, detectedobjects);

            foreach (Collider2D col in detectedobjects)
            {
                GameObject obj = col.gameObject;

                if (!alreadyDamaged.Contains(obj))
                {
                    alreadyDamaged.Add(obj);

                    Debug.Log(this.gameObject.name + " (Circle) detected: " + obj.name);

                    Health health = obj.GetComponent<Health>();

                    if (health != null){

                    health.Damage();

                    }
                    //_damage++;


                    // obj.GetComponent<Health>()?.Damage();
                }
            }
        }
    }
}

public void ApplyAOEDamage()
{
    ResetDamageState();             // clear before each loop

    DetectObjectsInsideAOE();       // check composite collider

    DetectObjectsCircleAOE();       // check circle colliders
}

}
