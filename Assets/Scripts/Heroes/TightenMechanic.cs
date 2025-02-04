using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TightenMechanic : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform heroesposition;
    private GameObject whoisobjectinside;

    public GameObject[] objectenter = new GameObject[10];
    
    int objectsintrigger = 0;

    int indexobject = 0;

    [SerializeField]
    GameObject tightposition;

    [SerializeField]
    float _speedtight = 5.0f;

    [SerializeField]
    GameObject _position;

    bool _tight = false;

    bool isReturning = false;

    private bool isCharging = false;

    void Start()
    {
        objectenter = new GameObject[10];
        
    }

    // Update is called once per frame
    void Update()
    {

        TightenInput();

    }

    void OnTriggerEnter2D(Collider2D other){

        indexobject++;

        objectenter[indexobject] = other.gameObject;
            
        objectsintrigger++;

        //Debug.Log(this.gameObject.name + " Jumlah Object didalam Trigger Enter " + objectsintrigger + " Kapasitas " + objectenter.Length + ", Object yang masuk: " + objectenter[indexobject].name + " Index " + indexobject + " Yang Trigger " + other.gameObject.name);

        if(other.gameObject.tag == "Heroes" && objectsintrigger == 1){

            whoisobjectinside = other.gameObject;

            //Debug.Log("Yang suruh gerak " + whoisobjectinside.name);

            _tight = true;

            heroesposition = whoisobjectinside.transform;


        }
        else if(other.gameObject.tag == "Heroes" && objectsintrigger == 2){

            _tight = false;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        indexobject--;

        objectsintrigger--;

        if(other.gameObject.tag == "Heroes" && objectsintrigger == 1){

            _tight = true;

            if(other.gameObject != objectenter[1]){

                whoisobjectinside = objectenter[1];

                /*Debug.Log("Whoisobjectinside " + whoisobjectinside);
                Debug.Log("Sisa " + objectenter[1].name);*/

                heroesposition = whoisobjectinside.transform;



            }
            else if(other.gameObject.tag == "Heroes" && other.gameObject == objectenter[1]){

                whoisobjectinside = objectenter[2];

                heroesposition = whoisobjectinside.transform;

                /*Debug.Log("Whoisobjectinside " + whoisobjectinside);
                Debug.Log("Sisa " + objectenter[2]);
                Debug.Log("Elseif " + whoisobjectinside.name);*/
            }


        }
        else {

            _tight = false;

        }

        //Debug.Log(this.gameObject.name + " Jumlah Object di Trigger Exit " + objectsintrigger +" Index Object Sekarang " + objectenter[indexobject] + " Index " + indexobject + " Yang trigger " + other.gameObject.name);
        
    }

private void TightenInput(){

    if(_tight == true){
        
        if(Input.GetKeyDown(KeyCode.F)){

        isCharging = true;

        //Debug.Log("Charging Start");

        }

        if(Input.GetKey(KeyCode.F) && isCharging){

        heroesposition.position = Vector2.MoveTowards(heroesposition.position,tightposition.transform.position, _speedtight * Time.deltaTime);

        //Debug.Log("Is Charging");

        }

        if(Input.GetKeyUp(KeyCode.F) && isCharging ){

        //Debug.Log("Release");

        isCharging = false;

        isReturning = true;
            
        }
            
    }

    if(isReturning == true){

        heroesposition.position = Vector2.MoveTowards(heroesposition.position,_position.transform.position, _speedtight * Time.deltaTime);

            if(Vector2.Distance(heroesposition.position,_position.transform.position) <0.1f){

                isReturning = false;

            }

    }

}
    
}
