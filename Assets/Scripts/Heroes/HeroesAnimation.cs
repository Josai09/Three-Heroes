using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesAnimation : MonoBehaviour
{

    Animator _childrenanimator;

    SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {

        _childrenanimator = GetComponentInChildren<Animator>();

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if(_childrenanimator != null){

            Debug.Log("Children Animator Found");

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float move, float side){

        _childrenanimator.SetFloat("Move", Math.Abs(move));

        if(side < 0){

            _spriteRenderer.flipX = true;

        }
        else if(side > 0){

            _spriteRenderer.flipX = false;

        }


    }

    public void SkillJ(){

        _childrenanimator.SetTrigger("J");


    }

    public void SkillK(){

        _childrenanimator.SetTrigger("K");


    }

    public void FlipTrue(){

        _spriteRenderer.flipX = true;

    }

    public void FlipFalse(){

        _spriteRenderer.flipX = false;

    }

}
