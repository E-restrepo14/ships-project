using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseMele : NpcClass
{
    public float speed;
    public string counterTag;

    void Awake()
    {
        AttakRange = 2.0f;
        speed = 10.0f;
        step = speed * Time.deltaTime;
        counterTag = "Gunner";
    }

    private void Update()
    {
        Combatir(counterTag);
    }

}