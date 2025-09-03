using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int _health;

    [SerializeField]
    int _skillpoint;
    // Start is called before the first frame update
    [SerializeField]
    int _damagedealt;

    public int _aggropoints = 0;

    [SerializeField]
    public int _basedaggroperhit;




    public void Start()
    {


    }

    // Update is called once per frame
    public void Update()
    {



    }

    public void Damage()
    {

        if (_health > 0)
        {

            _health--;

            Debug.Log(this.gameObject.name + "Damaged, Remaining Health " + _health);

        }

        else if (_health == 0)
        {

            Debug.Log(this.gameObject.name + "is Dead");
        }


    }

    public void AddAggro()
    {

        _aggropoints += _basedaggroperhit;

        Debug.Log("Aggropointsnya adalah " + _aggropoints + "dari gameobject " + this.gameObject) ;

        

    }
}
