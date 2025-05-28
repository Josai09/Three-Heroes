using UnityEngine;
using System.Collections.Generic;

public class IrregularShapeColliderDetector : MonoBehaviour
{
    
    public CompositeCollider2D compositeCollider;

    private PolygonCollider2D polygonCollider2D;
    private ContactFilter2D filter;
    private List<Collider2D> detectedObjects = new List<Collider2D>();
    private CircleCollider2D[] circlecolliders;
    private ContactFilter2D filtercircle;
    Health _healthscript;
    int _damage = 0;

    //bool _damageded = false;

    //bool _damagecirclestatus = false;

    private HashSet<GameObject> damagedObjectsThisFrame = new HashSet<GameObject>();

    private HashSet<GameObject> alreadyDamaged = new HashSet<GameObject>();

    //lagi ngerjain damage biar minusnya cuma 1

    

    public void Start()
    {
        

        polygonCollider2D = GetComponentInChildren<PolygonCollider2D>();

        
        circlecolliders = GetComponentsInChildren<CircleCollider2D>();

        _healthscript = GameObject.Find("Tank").GetComponent<Health>();

        if(circlecolliders == null){

            Debug.Log("Object doesn't have circle collider");

        }

        filtercircle.useTriggers = false;

        
    }

    public void Update()
    {

        //damagedObjectsThisFrame.Clear();

        //DetectObjectsInsideAOE();


        

        if(circlecolliders != null){

            //DetectObjectsCircleAOE();
            

        }


        

    }

    /*void DetectObjectsInsideAOE(){

        detectedObjects.Clear();

        Collider2D[] results = new Collider2D[10]; // Adjust size if needed

        int count = compositeCollider.OverlapCollider(filter, results);

        for (int i = 0; i < count; i++){

            if (results[i] != null)

            {
                detectedObjects.Add(results[i]);
                
                Debug.Log(this.gameObject.name + "Detected: " + results[i].gameObject.name);

                _damage++;

                _damageded = true;

                Debug.Log("Damage " + _damage);

                //_damage = 0;

                 //Debug.Log("Damage Reset " + _damage);

            }
        }

        
    }*/

public void DetectObjectsInsideAOE()
{
    compositeCollider = GetComponentInChildren<CompositeCollider2D>();

    detectedObjects.Clear();

    alreadyDamaged.Clear();

    Collider2D[] results = new Collider2D[10]; // Adjust size if needed

    int count = compositeCollider.OverlapCollider(filter, results);

    for (int i = 0; i < count; i++)
    {
        if (results[i] != null)
        {
            GameObject obj = results[i].gameObject;

            // Only damage if this object hasn't been damaged yet
            if (!alreadyDamaged.Contains(obj))
            {
                detectedObjects.Add(results[i]);
                alreadyDamaged.Add(obj); // Mark as damaged

                Debug.Log(this.gameObject.name + " Detected: " + obj.name);

                _damage++;
                Debug.Log("Damage " + _damage);

                
                // You can call _healthscript.Damage() here if needed
            }

            

        }
    }

    

    // Optional: If you want to clear the hashset when all objects exit
    // You'd need an OnTriggerExit2D or similar logic to detect when they leave
}/*void DetectObjectsCircleAOE(){

        
        foreach (CircleCollider2D collider in circlecolliders){

            List<Collider2D> detectedobjects = new List<Collider2D>();

            collider.OverlapCollider(filtercircle,detectedobjects);

            //if(_damagecirclestatus == false){

                foreach (Collider2D col in detectedobjects){

                Debug.Log(this.gameObject.name + "detected " + col.gameObject.name);

                //_healthscript.Damage();

                _damagecirclestatus = true;

                Debug.Log("Damage Circle " + _damagecirclestatus);

                }

            //}

        }

        
}*/

/*public void DetectObjectsInsideCircleAOE()
{
    compositeCollider = GetComponentInChildren<CompositeCollider2D>();

    detectedObjects.Clear();

    alreadyDamaged.Clear();

    Collider2D[] results = new Collider2D[10]; // Adjust size if needed

    int count = compositeCollider.OverlapCollider(filter, results);

    for (int i = 0; i < count; i++)
    {
        if (results[i] != null)
        {
            GameObject obj = results[i].gameObject;

            // Only damage if this object hasn't been damaged yet
            if (!alreadyDamaged.Contains(obj))
            {
                detectedObjects.Add(results[i]);
                alreadyDamaged.Add(obj); // Mark as damaged

                Debug.Log(this.gameObject.name + " Detected: " + obj.name);

                _damage++;
                Debug.Log("Damage " + _damage);

                
                // You can call _healthscript.Damage() here if needed
            }

            

        }
    }*/

    

    // Optional: If you want to clear the hashset when all objects exit
    // You'd need an OnTriggerExit2D or similar logic to detect when they leave

    
}

