using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcClass : MonoBehaviour
{
    public GameObject target;
    public Transform VigilanceSpot;
    public Transform ScapeWay;
    public float AttakRange;
    public bool seRetira;
    public float step;




    public void Combatir(string counterTag)
    {
        if (seRetira == false)
        {
            target = GameObject.FindGameObjectWithTag(counterTag);

            if (target != null)
            {
                Atacar(target,AttakRange);
            }
            else
            {
                Formar(VigilanceSpot);
            }
        }
        else
        {
            gameObject.tag = "Untagged";
            transform.position = Vector3.MoveTowards(transform.position, ScapeWay.position, step * 2);
        }
    }

    public void Formar(Transform waypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, step);
    }

    public void Retirarse()
    {
        seRetira = true;
    }

    public void Atacar(GameObject target, float rangeValue)
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (rangeValue >= dist)
        {
            print("insertar animacion de atacar");
            Retirarse();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }

}