using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    // en este script estan almacenados por array... los obstaculos, adornos y sus respectivas posiciones en los cuales se instanciarán al azar, por un random range.

    public static Instanciador Instance;
    public bool estaJugando = false;
    public float NextTime = 2f;
    [SerializeField]
    private float waitTime = 0;

    [SerializeField]
    private GameObject[] enemyWaypoints;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    private void Update()
    {
        if (estaJugando == true)
        {
            Instanciar();
        }
    }

    public void Parar()
    {
        estaJugando = false;
    }

    void Instanciar()
    {
        while (Time.fixedTime > waitTime)
        {
            int enemyType = Random.Range(0, 3);

            switch (enemyType)
            {

                case 0:
                    enemyWaypoints[Random.Range(0, (enemyWaypoints.Length))].GetComponent<InstantiateManager>().CallGunner(2);
                    break;
                case 1:
                    enemyWaypoints[Random.Range(0, (enemyWaypoints.Length))].GetComponent<InstantiateManager>().CallAssassin(2);
                    break;
                case 2:
                    enemyWaypoints[Random.Range(0, (enemyWaypoints.Length))].GetComponent<InstantiateManager>().CallDefender(2);
                    break;
                default:
                    print("incorrect level");
                    break;
            }

            waitTime = NextTime + Time.fixedTime;
            
        }
    }

   
}
