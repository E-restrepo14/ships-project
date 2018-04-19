using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseAsedio : NpcClass
{
    public float speed;
    public string counterTag;

    void Awake()
    {
        AttakRange = 24.0f;
        speed = 3.0f;
        step = speed * Time.deltaTime;
        counterTag = "Defender";
    }

    private void Update()
    {
        Combatir(counterTag);
    }

}