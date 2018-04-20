using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseMele : NpcClass
{
    public float speed;
    public string counterTag;
    public string secondTag;

    void Awake()
    {
        AttakRange = 2.0f;
        speed = 10.0f;
        step = speed * Time.deltaTime;
    }

    private void Update()
    {
        Combatir(counterTag, secondTag);
    }

}