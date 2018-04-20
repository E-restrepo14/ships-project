using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseAsedio : NpcClass
{
    public float speed;
    public string counterTag;
    public string secondTag;
    [SerializeField]
    private GameObject Bala;
    float NextTime = 0;
    int counter = 5;

    // los camellos atacaran con una particula de electricidad
    // los lanzaflechas atacarán con una electricidad diferente pero que es a distancia
    // las catapultas atacarán con una electricidad mas grande que las otras

    void Awake()
    {
        AttakRange = 24.0f;
        speed = 3.0f;
        step = speed * Time.deltaTime;
    }

    private void Update()
    {
        Combatir(counterTag, secondTag);

        if (isAttacking == true)
        {
            if (Time.fixedTime > NextTime)
            {
                NextTime = Time.fixedTime + 3;
                GameObject proyectil = Instantiate(Bala, transform.position, transform.rotation) as GameObject;
                proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 800);
                Destroy(proyectil,7);
                counter--;
            }
            
        }

    }

}