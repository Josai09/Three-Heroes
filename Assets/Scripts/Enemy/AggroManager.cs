using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AggroManager : MonoBehaviour
{

    public static AggroManager Instance;

    public List<GameObject> heroes = new List<GameObject>();

    public GameObject target;

    Health _healthhandler;

    Boss01 boss01;

    void Awake()
    {
        Instance = this;

    }
    void Start()
    {

        boss01 = GameObject.Find("Demon").GetComponent<Boss01>();

        heroes = GameObject.FindGameObjectsWithTag("Heroes").ToList();

    }


    public void TestDamageSource(GameObject source)
    {

        _healthhandler = source.GetComponent<Health>();

        //int aggropoint = _healthhandler._aggropoints;

        Debug.Log("Source of damage " + source.name);

        target = source;

        //boss01.TargetandMove(target);

        Debug.Log("target" + target);

        //Debug.Log("Aggro points " + aggropoint);

    }

    public void UpdateTargetByAggro()
    {

        if (heroes.Count == 0) return;

        var sortedheroes = heroes.OrderByDescending(h => h.GetComponent<Health>()._aggropoints).ToList();

        target = sortedheroes[0];

        Debug.Log("New target is " + target.name + " with aggro " + target.GetComponent<Health>()._aggropoints);


    }


}
