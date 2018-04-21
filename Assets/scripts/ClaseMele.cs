using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseMele : NpcClass
{
    public float speed;
    public string counterTag;
    public string secondTag;
    [SerializeField]
    private GameObject privateShoot;
    float NextTime = 0;
    int counter = 1;

    void Awake()
    {
        AttakRange = 2.0f;
        speed = 10.0f;
        step = speed * Time.deltaTime;
    }

    private void Update()
    {
        Combatir(counterTag, secondTag);
        if (isAttacking == true)
        {
            if (Time.fixedTime > NextTime)
            {
                NextTime = Time.fixedTime + counter;
                GameObject proyectil = Instantiate(privateShoot, transform.position, transform.rotation) as GameObject;
                proyectil.GetComponent<ClaseProyectil>().targetTag = counterTag;
                proyectil.GetComponent<ClaseProyectil>().secondTargetTag = secondTag;
                Destroy(proyectil, 7);
            }

        }

    }

}