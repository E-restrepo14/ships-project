using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseQueen : NpcClass
{
    public float speed;
    public string counterTag;
    public string secondTag;
    [SerializeField]
    private GameObject privateShoot;
    float NextTime = 0;
    //counter deberia haberse llamado tiempo de carga de disparo.
    int counter = 5;

    void Awake()
    {
        //al tener tanto rango, talvez nisiquiera llegue a formarse en donde debe para ir hacia el prota
        AttakRange = 80f;
        speed = 3.0f;
        step = speed * Time.deltaTime;
    }

    private void Update()
    {      
        transform.position = Vector3.MoveTowards(transform.position, vigilanceSpot.position, step);
       

        Combatir(counterTag, secondTag);
        if (isAttacking == true)
        {
            if (Time.fixedTime > NextTime)
            {
                NextTime = Time.fixedTime + counter;
                GameObject proyectil = Instantiate(privateShoot, transform.position, transform.rotation) as GameObject;
                proyectil.GetComponent<ClaseProyectilEspecial>().targetTag = counterTag;
                proyectil.GetComponent<ClaseProyectilEspecial>().safeTag = gameObject.tag;
                proyectil.GetComponent<ClaseProyectilEspecial>().secondTargetTag = secondTag;
                Destroy(proyectil, 10);
            }

        }

    }

    public IEnumerator BajarVida()
    {
        if (vida >= 1)
        {
            vida--;
            yield return new WaitForSeconds(0);
        }
        else
            Destroy(gameObject);
    }

}
