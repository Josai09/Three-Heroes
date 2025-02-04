using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class DPS : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D _rigid;

    private Vector2 InputKey;

    [SerializeField]
    float _speed = 50;

    [SerializeField]
    float _delay = 1; 
    [SerializeField]
    float _strength = 20;

    private Vector2 movementInput;

    [SerializeField]
    private InputActionReference movement,attack;

    public void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

        if( _rigid != null ){

            Debug.Log("Rigidbody found");

        }
    }

    // Update is called once per frame
    public void Update()
    {

        movementInput = movement.action.ReadValue<Vector2>();


        //InputKey = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }

    public void FixedUpdate() {

        _rigid.velocity = movementInput * _speed;

    }


}
