using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.GameCenter;

public class Heroes : MonoBehaviour
{
    float fliphero0,fliphero2 = 0;

    int selectedheroindex;

    [SerializeField]
    private InputActionReference movement,attack,spread;
    [SerializeField]
    float _speed;
    [SerializeField]
    public GameObject[] positions;

    [SerializeField]
    public GameObject _boss;
    private Vector2 movementinput,attackinput,spreadinput;
    public GameObject[] heroes;
    private bool individualmode = false;
    public Rigidbody2D[] _rigidbodyheroesindex;
    private int currentheroesindex = 0;
    public Rigidbody2D _rigidbodyindividual;

    private HeroesAnimation[] _heroesanimationindex;

    private HeroesAnimation animationheroes2;

    private HeroesAnimation animationheroes1;

    private HeroesAnimation animationheroes0;

    
    // Start is called before the first frame update
    void Start()
    {
        animationheroes2 = heroes[2].GetComponent<HeroesAnimation>();

        animationheroes1 = heroes[1].GetComponent<HeroesAnimation>();

        animationheroes0 = heroes[0].GetComponent<HeroesAnimation>();

        _heroesanimationindex = GetComponentsInChildren<HeroesAnimation>();

        //_heroesanimation = GetComponentInChildren<HeroesAnimation>();

        if(_rigidbodyheroesindex != null){

            Debug.Log("Rigidbodyheroes found");

        }

        if(_heroesanimationindex != null){

            Debug.Log("Heroes Animation Found");

        }

        /*GameObject currenthero = heroes[0];

        Rigidbody2D rigidbodycurrenthero = currenthero.GetComponent<Rigidbody2D>();

        SpriteRenderer spriterenderercurrenthero = currenthero.GetComponentInChildren<SpriteRenderer>();

        if(spriterenderercurrenthero != null){

            Debug.Log("Sprite Renderer Current Hero Found");

        spriterenderercurrenthero.color = Color.red;
        }*/

    }

    // Update is called once per frame
    void Update()
    {

        //below is hardcode please find another way if have the time
        IndividualFLip0();

        IndividualFlip1();
        
        IndividualFlip2();
        //FLiptoBoss();
        
        IndividualModeChecker();

        HeroesSelector();

        Movement();

        SpreadMechanic();

    }

    private void Movement(){

        if(individualmode == true){

        SelectPlayer(currentheroesindex);

        }

        else{

        MovementGroup();
            

        }

    }

    private void IndividualModeChecker(){

        if(Input.GetKeyDown(KeyCode.R) == true){

            if(individualmode == true){

                individualmode = false;

                SelectPlayer(currentheroesindex);

                Debug.Log("Individual Mode False");


            }
            else if(individualmode == false){

                individualmode = true;

                Debug.Log("Individual Mode True");

                

            }

        }

    }

    private void SelectPlayer(int index){

        currentheroesindex = index;

        for (int i = 0; i <heroes.Length; i++){

            Transform selector = heroes[i].transform.Find("Selector");

            if(individualmode == true && i == currentheroesindex){

                selectedheroindex = i;

                MovementIndividual(selectedheroindex);


                //FliptoBossIndividual(selectedheroindex);

                HeroesAnimation heroanimationselected = heroes[selectedheroindex].GetComponentInChildren<HeroesAnimation>();
                
                float move = movementinput.magnitude;

                float side = movementinput.x;

                heroanimationselected.Move(move,side);

                //heroes[i].GetComponentInChildren<SpriteRenderer>().color = Color.white;
                
                //this if for movement

                //this is for animation when moving

                //this is for skills of the hero
                IndividualSkillHeroes(currentheroesindex);


                //this is for selector triangle active
                selector.transform.gameObject.SetActive(true);


            }
            else if(individualmode == true &&i != currentheroesindex){

                //heroes[i].GetComponentInChildren<SpriteRenderer>().color = Color.yellow;

                HeroesAnimation heroanimationselected = heroes[i].GetComponentInChildren<HeroesAnimation>();
                               
                heroanimationselected.Move(0,0);

                selector.transform.gameObject.SetActive(false);

            }
            

            if(individualmode == false){

                //heroes[i].GetComponentInChildren<SpriteRenderer>().color = Color.white;

                selector.transform.gameObject.SetActive(false);

                Debug.Log("Masuk");

            }


        }


    }

    private void HeroesSelector(){

        if(individualmode == true){

            if(Input.GetKeyDown(KeyCode.Space) == true){

                currentheroesindex = currentheroesindex + 1;

            }

        }

        if(currentheroesindex == heroes.Length){

            currentheroesindex = 0;

        }

    }

    private void IndividualSkillHeroes(int currentheroesindex){

        HeroesAnimation heroanimationselected = heroes[currentheroesindex].GetComponentInChildren<HeroesAnimation>();

        if(Input.GetKeyDown(KeyCode.J) == true){

            Debug.Log(heroes[currentheroesindex] + " Skill J Activated");

            heroanimationselected.SkillJ();

        }

        else if(Input.GetKeyDown(KeyCode.K) == true){

            Debug.Log(heroes[currentheroesindex] + " Skill K Activated");

            heroanimationselected.SkillK();

        }

    }

    private void SpreadMechanic(){

        
        if(heroes[0].transform.position.x < heroes[1].transform.position.x){

            //heroes0 is on the left

            fliphero0 = 1;


        }
        else if(heroes[0].transform.position.x > heroes[1].transform.position.x){

            fliphero0 = -1;

        }

        if(heroes[2].transform.position.x < heroes[1].transform.position.x){

            //heroes0 is on the left

            fliphero2 = 1;


        }
        else if(heroes[2].transform.position.x > heroes[1].transform.position.x){

            fliphero2 = -1;

        }

    if(Input.GetKey(KeyCode.E) == true){


            heroes[2].transform.position =  Vector2.MoveTowards(heroes[2].transform.position,positions[1].transform.position,_speed * Time.deltaTime);

            heroes[0].transform.position =  Vector2.MoveTowards(heroes[0].transform.position,positions[0].transform.position,_speed * Time.deltaTime);

            animationheroes0.Move(1,fliphero0);

            animationheroes2.Move(1,fliphero2);

        }

    else if (Input.GetKey(KeyCode.Q) == true){

            float directionX0 = heroes[0].transform.position.x > heroes[1].transform.position.x ? 1f:-1f;

            float directionX2 = heroes[2].transform.position.x > heroes[1].transform.position.x ? 1f:-1f;
            
            heroes[0].transform.position += new Vector3(directionX0 *_speed* Time.deltaTime,0,0);
            
            heroes[2].transform.position += new Vector3(directionX2 *_speed* Time.deltaTime,0,0);

            animationheroes0.Move(1,-fliphero0);

            animationheroes2.Move(1,-fliphero2); 

        }

    }

    private void MovementGroup(){

        foreach(Rigidbody2D _rigidbodyheroes in _rigidbodyheroesindex){

            movementinput = movement.action.ReadValue<Vector2>();

            _rigidbodyheroes.velocity = movementinput * _speed;

            float move = movementinput.magnitude;

            float side = movementinput.x;

            foreach(HeroesAnimation _heroesanimation in _heroesanimationindex){
                    
                //move animation

                _heroesanimation.Move(move,side);

            }
            
                //_heroesanimation.Move(move);

        }

    }

    private void MovementIndividual(int selectedheroindex){

        Rigidbody2D rigidbodycurrenthero = heroes[selectedheroindex].GetComponentInChildren<Rigidbody2D>();
                
        movementinput = movement.action.ReadValue<Vector2>();
                
        rigidbodycurrenthero.velocity = movementinput * _speed;


                
    }

    private void FLiptoBoss(){

        for (int i = 0; i < heroes.Length; i++){

            
            if (heroes[i].transform.position.x > _boss.transform.position.x){

                foreach(HeroesAnimation _heroesanimation in _heroesanimationindex){
                    
                //move animation

                _heroesanimation.FlipTrue();

                }
            }

            else if(heroes[i].transform.position.x < _boss.transform.position.x){

                foreach(HeroesAnimation _heroesanimation in _heroesanimationindex){
                    
                //move animation

                _heroesanimation.FlipFalse();
   
                }
            }

            /*else if(heroes[currentheroesindex].transform.position.x < _boss.transform.position.x){

                
                foreach(HeroesAnimation _heroesanimation in _heroesanimationindex){
                    
                //move animation

                _heroesanimation.FlipTrue();

                }

            }
            else if(heroes[currentheroesindex].transform.position.x > _boss.transform.position.x){

                foreach(HeroesAnimation _heroesanimation in _heroesanimationindex){
                    
                //move animation

                _heroesanimation.FlipFalse();

                }
        
            }*/

            }

        }

    /*private void FliptoBossIndividual(int selectedheroindex){

            int currentheroesindexadd = selectedheroindex;

            HeroesAnimation heroanimationselected = heroes[selectedheroindex].GetComponentInChildren<HeroesAnimation>();

            if(heroes[selectedheroindex].transform.position.x > _boss.transform.position.x){

                
                heroanimationselected.FlipTrue();

                

            }
            else if(heroes[selectedheroindex].transform.position.x < _boss.transform.position.x){
                    
                //move animation

                heroanimationselected.FlipFalse();

                
        
            }


    }*/

    private void IndividualFlip1(){

        if(heroes[1].transform.position.x > _boss.transform.position.x){

                
            animationheroes1.FlipTrue();
                

        }
        else if(heroes[1].transform.position.x < _boss.transform.position.x){
                    
                //move animation

            animationheroes1.FlipFalse();

    
        }


    }

    private void IndividualFlip2(){

        if(heroes[2].transform.position.x > _boss.transform.position.x){

                
            animationheroes2.FlipTrue();
                

        }
        else if(heroes[2].transform.position.x < _boss.transform.position.x){
                    

            animationheroes2.FlipFalse();

    
        }


    }

    private void IndividualFLip0(){

        if(heroes[0].transform.position.x > _boss.transform.position.x){

                
            animationheroes0.FlipTrue();
                

        }
        else if(heroes[0].transform.position.x < _boss.transform.position.x){
                    
                //move animation

            animationheroes0.FlipFalse();

    
        }


    }

}



