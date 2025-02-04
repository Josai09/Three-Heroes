using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class KnockBack : MonoBehaviour
{
    // Start is called before the first frame update

    CompositeCollider2D _compositecollider2d;

    Rigidbody2D _rigidbodyheroes;

    [SerializeField]
    public float knockbackForce = 10f;

    bool _knockback = false;

    void Start()
    {

        //_compositecollider2d = GetComponentInChildren<CompositeCollider2D>();

        _rigidbodyheroes = GameObject.Find("DPS").GetComponent<Rigidbody2D>();



       /* if( _compositecollider2d != null ){

            Debug.Log("Composite Collider Found");
        }*/

        if(_rigidbodyheroes != null ){

            Debug.Log("RigidBody Heroes");

        }


        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_knockback == true){

            _rigidbodyheroes.velocity = Vector3.zero;

            //_rigidbodyheroes.AddForce(new Vector2(100,100),ForceMode2D.Impulse);

            Knock();
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        /*Rigidbody2D rigidbodyknockback = other.gameObject.GetComponent<Rigidbody2D>();

        if (rigidbodyknockback != null){

            Debug.Log("Ketemu");

            Vector2 direction = ( rigidbodyknockback.position - new Vector2(transform.position.x,transform.position.y)).normalized;

            rigidbodyknockback.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

            Invoke(nameof(ResetKnockback), 1f);

        }*/


        

        if(other.gameObject.tag == "Heroes"){

            Debug.Log("KnockBack");

            _knockback = true;


        }
        
    }

    private void Knock(){

        Vector2 direction = (new Vector2(transform.position.x,transform.position.y)-_rigidbodyheroes.position).normalized;

        _rigidbodyheroes.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        Invoke(nameof(ResetKnockback), 1f);

        

    }

    private void ResetKnockback(){

        _knockback = false;

        Debug.Log("I cook Cream Soup");

    }
}

