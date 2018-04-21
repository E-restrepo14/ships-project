using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseTorre : NpcClass
{
    public float speed;
    public string counterTag;
    public string secondTag;
    [SerializeField]
    private GameObject privateShoot;
    float NextTime = 0;
    int counter = 3;

    void Awake()
    {
        AttakRange = 12.0f;
        speed = 6.0f;
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