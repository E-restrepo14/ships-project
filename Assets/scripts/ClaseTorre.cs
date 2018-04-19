using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseTorre : NpcClass
{
    public float speed;
    public string counterTag;

    void Awake()
    {
        AttakRange = 12.0f;
        speed = 6.0f;
        step = speed * Time.deltaTime;
        counterTag = "Assassin";
    }

    private void Update()
    {
        Combatir(counterTag);
    }

}