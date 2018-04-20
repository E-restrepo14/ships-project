using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseTorre : NpcClass
{
    public float speed;
    public string counterTag;
    public string secondTag;

    void Awake()
    {
        AttakRange = 12.0f;
        speed = 6.0f;
        step = speed * Time.deltaTime;
    }

    private void Update()
    {
        Combatir(counterTag, secondTag);
    }

}