using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;
public class HeroesAttack : MonoBehaviour
{
    private Hitbox hitbox;
    private Boss01 boss01;

    AggroManager aggroManager;
    Health _stats;

    void Start()
    {
        hitbox = GetComponentInChildren<Hitbox>();
        boss01 = GameObject.Find("Demon").GetComponent<Boss01>();
        aggroManager = GameObject.Find("Manager").GetComponent<AggroManager>();
        _stats = GetComponentInParent<Health>();

        if (_stats != null)
        {
            Debug.Log("Handler found");
        }
    

    }

    // Called by Animation Event at the exact frame of impact
    /*public void OnEvent()
    {
        Debug.Log("Attack Event Triggered");

        Debug.Log("is boss inside value " + hitbox.IsBossInside());

        Debug.Log("#Attack Event Triggered");
        Debug.Log("#Hitbox reference: " + hitbox.GetInstanceID());
        Debug.Log("#is boss inside value " + hitbox.IsBossInside());


        if (hitbox.IsBossInside() == true)
        {
            boss01.BossDamaged();
        }
    }*/

    public void OnEvent()
    {
       // Debug.Log("#Attack Event Triggered");

        StartCoroutine(DelayedDamageCheck());

    }

    private IEnumerator DelayedDamageCheck()
    {
        yield return new WaitForFixedUpdate(); // wait for physics step

        //Debug.Log("is boss inside value " + hitbox.IsBossInside());

        if (hitbox.IsBossInside())
        {
            boss01.BossDamaged();

            //AggroManager.Instance.TestDamageSource(transform.parent.gameObject);

            AggroManager.Instance.UpdateTargetByAggro();

            _stats.AddAggro();

        

            
        }
    }

    public void OnDisable()
    {
    
    }


}
