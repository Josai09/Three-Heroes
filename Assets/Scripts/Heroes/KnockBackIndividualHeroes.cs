using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackIndividualHeroes : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D _rigidbodyheroes;

    Rigidbody2D _rigidbodybounds;

    float knockbackforce = 10f;

    bool knockback = false;

    //bool trigger = false;

    //Vector2 otherobject;

    /*[SerializeField]
    float _speed = 5f;*/

    //[SerializeField]
    //GameObject tightposition;

    public void Start()
    {

        _rigidbodyheroes = GetComponent<Rigidbody2D>();

        _rigidbodybounds = GameObject.Find("Ground").GetComponent<Rigidbody2D>();

        if(_rigidbodyheroes != null){

            Debug.Log("Rigidbodyheroes found");



        }
        
    }

    public void FixedUpdate(){

        if(knockback == true){

            _rigidbodyheroes.velocity = Vector3.zero;

            ApplyKnockBack();
        }

    }

    public void Update(){

        /*if(trigger == true){


            if(Input.GetKeyDown(KeyCode.Q) == true){

                otherobject = Vector2.MoveTowards(otherobject,tightposition.transform.position, _speed * Time.deltaTime);

                Debug.Log("GetKey2");
            }

        }*/

        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Bounds"){

            Debug.Log("Bounds");

            knockback = true;
        }

        
        
    }

    /*public void  OnTriggerEnter2D(Collider2D other) {

        

        if(other.gameObject.tag == "Trigger"){

            trigger = true;

            Debug.Log("Trigger");

            otherobject = other.transform.position ;

            Debug.Log(otherobject + " " + other.gameObject.name);


        }
        
    }*/

    void ApplyKnockBack(){

        Vector2 direction = (_rigidbodyheroes.position - _rigidbodybounds.position).normalized;

        _rigidbodyheroes.AddForce(direction * knockbackforce, ForceMode2D.Impulse);

        Invoke(nameof(ResetKnockback), 1f);

    }

    private void ResetKnockback(){

        knockback = false;

        Debug.Log("Knockback False");

    }

    /*private void Tight(GameObject tightposition){

        
    }*/
}
