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

    bool _isAttacking = false;

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

        if(!_isAttacking){

            StartCoroutine(AttackRoll());

        }

        
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

    IEnumerator AttackRoll(){

        _isAttacking = true;

        int RandomNumber = Random.Range(1,6);

        Debug.Log("random" + RandomNumber);


        if(RandomNumber == 1){

            _spriteanimator.SetTrigger("1");

            yield return null;

            while (!_spriteanimator.GetCurrentAnimatorStateInfo(0).IsName("AOE_attack")){

                yield return null;
            }

            AnimatorStateInfo stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.normalizedTime < 1.0f) {

                yield return null;

                stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            }

            _isAttacking = false;


        }
        else if (RandomNumber == 2){

            _spriteanimator.SetTrigger("2");

            yield return null;

            while(!_spriteanimator.GetCurrentAnimatorStateInfo(0).IsName("AOE_position")){

                yield return null;

            }

            AnimatorStateInfo stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.normalizedTime < 1.0f) {

                yield return null;

                stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            }
            
            _isAttacking = false;

        }
        else if (RandomNumber == 3){

            _spriteanimator.SetTrigger("3");

            yield return null;

            while (!_spriteanimator.GetCurrentAnimatorStateInfo(0).IsName("AOE_donut")){

                yield return null;

            }

            AnimatorStateInfo stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.normalizedTime < 1.0f){

                yield return null;

                stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);
            }

            _isAttacking = false;

        }
        else if (RandomNumber == 4){

            _spriteanimator.SetTrigger("4");

            yield return null;

            while(!_spriteanimator.GetCurrentAnimatorStateInfo(0).IsName("Knockback_attack")){

                yield return null;
            }

            AnimatorStateInfo stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.normalizedTime < 1.0f){

                yield return null;

                stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            }

            _isAttacking = false;


        }
        else if (RandomNumber == 5){

            _spriteanimator.SetTrigger("5");

            yield return null;

            while (!_spriteanimator.GetCurrentAnimatorStateInfo(0).IsName("StackMarker_attack")){

                yield return null;

            }

            AnimatorStateInfo stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            while(stateInfo.normalizedTime < 1.0f){

                yield return null;

                stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            }

            _isAttacking = false;


        }

        

        


    }

}
