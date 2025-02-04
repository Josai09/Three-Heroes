using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public GameObject _target;

    [SerializeField]
    float _speed = 1;

    Animator _spriteanimator;

    SpriteRenderer _spriterenderer;

    void Start()
    {
        //ngejer musuh (aggro sistem)
        //chip attack
        //Undodgeable Attack (AOE,Knockback,Donut AOE, Stack Marker)

        _spriteanimator = GetComponentInChildren<Animator>();

        _spriterenderer = GetComponentInChildren<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {

        TargetandMove();

        FliptoTarget();

        
    }

    private void TargetandMove(){

        float distance = Vector3.Distance(_target.transform.position, this.transform.position);

        this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position,_target.transform.position,_speed * Time.deltaTime);

        MoveAnimation(distance);
        

    }

    private void MoveAnimation(float distance){

        if(distance > 0){

            _spriteanimator.SetBool("Walk",true);

        }
        else if(distance == 0){

            _spriteanimator.SetBool("Walk",false);

        }

    }

    private void FliptoTarget(){

        if(_target.transform.position.x > this.transform.position.x){

            _spriterenderer.flipX = true;

        }
        else{

            _spriterenderer.flipX = false;

        }

    }

}
