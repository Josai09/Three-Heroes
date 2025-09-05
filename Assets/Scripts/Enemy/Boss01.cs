using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01 : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject _target;
    //kalo mw dibalikit semuanyakudu jagi _target update juga diilangin commentnya

    [SerializeField]
    float _speed = 1;

    [SerializeField]
    int _bosshealth = 100;

    Animator _spriteanimator;

    SpriteRenderer _spriterenderer;

    bool _isAttacking = false;

    void Start()
    {
        //ngejer musuh (aggro sistem)
        //chip attack
        //Undodgeable Attack (AOE,Knockback,Donut AOE, Stack Marker)
        //bosshealth

        _spriteanimator = GetComponentInChildren<Animator>();

        _spriterenderer = GetComponentInChildren<SpriteRenderer>();

        if (AggroManager.Instance.target == null)
        {

            GameObject[] heroes = GameObject.FindGameObjectsWithTag("Heroes");

            if (heroes.Length > 0)
            {

                AggroManager.Instance.target = heroes[0];

                Debug.Log("Target set to " + heroes[0].name);

            }
            else
            {

                Debug.Log("No tag heroes found");

            }

        }
        
        _target = AggroManager.Instance.target;


    }

    // Update is called once per frame
    void Update()
    {
        _target = AggroManager.Instance.target;

        TargetandMove();

        FliptoTarget();

        float distance = Vector3.Distance(_target.transform.position, this.transform.position);


        if (!_isAttacking && distance < 1.5f)
        {

            StartCoroutine(AttackRoll());

        }


    }

    public void TargetandMove()
    {
        if(_target == null) return;

        if (_isAttacking)
        {
            _spriteanimator.SetBool("Walk", false);

            return;
        }
        
        float distance = Vector3.Distance(_target.transform.position, this.transform.position);
        
        this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, _target.transform.position, _speed * Time.deltaTime);

        MoveAnimation(distance);

    }

    private void MoveAnimation(float distance)
    {

        if (distance > 0)
        {
            
            _spriteanimator.SetBool("Walk", true);

            //_isAttacking = false;

        }
        else if (distance == 0)
        {

            _spriteanimator.SetBool("Walk", false);

            //_isAttacking = true;




        }

    }

    private void FliptoTarget()
    {

        if (_target.transform.position.x > this.transform.position.x)
        {

            _spriterenderer.flipX = true;

        }
        else
        {

            _spriterenderer.flipX = false;

        }

    }

    IEnumerator AttackRoll()
    {

        _isAttacking = true;

        int RandomNumber = 1;
        //int RandomNumber = Random.Range(1, 6);
        //int RandomNumber = Random.Range(1,3);

        Debug.Log("random" + RandomNumber);


        if (RandomNumber == 1)
        {

            _spriteanimator.SetTrigger("1");

            //yield return null;

            while (!_spriteanimator.GetCurrentAnimatorStateInfo(0).IsName("AOE_attack"))
            {

                yield return null;
            }

            AnimatorStateInfo stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.normalizedTime < 1.0f)
            {

                yield return null;

                stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            }

            _isAttacking = false;


        }
        else if (RandomNumber == 2)
        {

            _spriteanimator.SetTrigger("2");

            yield return null;

            while (!_spriteanimator.GetCurrentAnimatorStateInfo(0).IsName("AOE_position"))
            {

                yield return null;

            }

            AnimatorStateInfo stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.normalizedTime < 1.0f)
            {

                yield return null;

                stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            }

            _isAttacking = false;

        }
        else if (RandomNumber == 3)
        {

            _spriteanimator.SetTrigger("3");

            yield return null;

            while (!_spriteanimator.GetCurrentAnimatorStateInfo(0).IsName("AOE_donut"))
            {

                yield return null;

            }

            AnimatorStateInfo stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.normalizedTime < 1.0f)
            {

                yield return null;

                stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);
            }

            _isAttacking = false;

        }
        else if (RandomNumber == 4)
        {

            _spriteanimator.SetTrigger("4");

            yield return null;

            while (!_spriteanimator.GetCurrentAnimatorStateInfo(0).IsName("Knockback_attack"))
            {

                yield return null;
            }

            AnimatorStateInfo stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.normalizedTime < 1.0f)
            {

                yield return null;

                stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            }

            _isAttacking = false;


        }
        else if (RandomNumber == 5)
        {

            _spriteanimator.SetTrigger("5");

            yield return null;

            while (!_spriteanimator.GetCurrentAnimatorStateInfo(0).IsName("StackMarker_attack"))
            {

                yield return null;

            }

            AnimatorStateInfo stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.normalizedTime < 1.0f)
            {

                yield return null;

                stateInfo = _spriteanimator.GetCurrentAnimatorStateInfo(0);

            }

            _isAttacking = false;

        }

    }

    public void BossDamaged()
    {
        if (_bosshealth > 0)
        {
            _bosshealth--;

            Debug.Log("Boss Health " + _bosshealth);
        }

    }

}
