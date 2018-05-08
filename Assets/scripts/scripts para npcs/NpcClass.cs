using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcClass : MonoBehaviour
{
    public GameObject secondTarget;
    public GameObject target;
    public Transform vigilanceSpot;
    public Transform scapeWay;
    public float AttakRange;
    public bool seRetira;
    public bool isAttacking;
    public float step;
    public int vida = 4;




    public void Combatir(string counterTag,string secondTag)
    {
        if (seRetira == false)
        {
            if (vida >= 0)
            {
                target = GameObject.FindGameObjectWithTag(counterTag);
                if (target != null)
                {
                    Atacar(target, AttakRange);
                }

                else
                {
                    secondTarget = GameObject.FindGameObjectWithTag(secondTag);
                    if (secondTarget != null)
                    {
                        Atacar(secondTarget, AttakRange);
                    }
                    else
                    {
                        Formar(vigilanceSpot);
                    }
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.LookAt(scapeWay);
            Destroy(gameObject, 5);
            gameObject.tag = "Untagged";
            transform.position = Vector3.MoveTowards(transform.position, scapeWay.position,20*Time.deltaTime);
        }
    }

    public void Formar(Transform waypoint)
    {
        float dist = Vector3.Distance(waypoint.position,transform.position);
        transform.LookAt(waypoint);
        isAttacking = false;
        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, step);
        if (dist <=1)
        {
            transform.rotation = waypoint.rotation;
        }
    }

    public void Retirarse()
    {
        seRetira = true;
        isAttacking = false;
    }

    public void Atacar(GameObject target, float rangeValue)
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (rangeValue >= dist)
        {
            transform.LookAt(target.transform);
            isAttacking = true;
        }
        else
        {           
            transform.LookAt(target.transform);

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }

}