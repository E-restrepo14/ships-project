using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateManager : MonoBehaviour
{
    //este codigo le asigna el tag del enemigo principal a la nave instanciada, tambien el punto de escape y el punto de formacion
    //para que ente script funcione se le deben asignar variables desde el inspector, para que los soldados sean aliados se debe dar el argumento "equipo" = 1
    // "Target1" y "Player" son los tag para identificar los bosses y al player.

    [SerializeField]
    private GameObject gunnerShipPrefab;
    [SerializeField]
    private GameObject assassinShipPrefab;
    [SerializeField]
    private GameObject DefenderShipPrefab;

    [SerializeField]
    private Transform lineaDefensiva;
    [SerializeField]
    private Transform lineaMedia;
    [SerializeField]
    private Transform lineaFrontal;

    [SerializeField]
    private Transform scapeWayTransform;

    private void Start()
    {
        lineaDefensiva = transform.GetChild(0);
        lineaMedia = transform.GetChild(1);
        lineaFrontal = transform.GetChild(2);
        scapeWayTransform = transform.GetChild(3);
    }


    public void CallGunner(int equipo)
    {
        GameObject naveInstanciada = Instantiate(gunnerShipPrefab, transform.position, transform.rotation) as GameObject;
        naveInstanciada.GetComponent<ClaseAsedio>().vigilanceSpot = lineaFrontal;
        naveInstanciada.GetComponent<ClaseAsedio>().scapeWay = scapeWayTransform;

        if (equipo == 1)
        {
            naveInstanciada.GetComponent<ClaseAsedio>().counterTag = "EnemyDefender";
            naveInstanciada.GetComponent<ClaseAsedio>().secondTag = "Target1";
        }
        else
        {
            naveInstanciada.GetComponent<ClaseAsedio>().counterTag = "Defender";
            naveInstanciada.GetComponent<ClaseAsedio>().secondTag = "Player";
        }
    }

    public void CallAssassin(int equipo)
    {
        GameObject naveInstanciada = Instantiate(assassinShipPrefab, transform.position, transform.rotation) as GameObject;
        naveInstanciada.GetComponent<ClaseMele>().vigilanceSpot = lineaDefensiva;
        naveInstanciada.GetComponent<ClaseMele>().scapeWay = scapeWayTransform;

        if (equipo == 1)
        {
            naveInstanciada.GetComponent<ClaseMele>().counterTag = "EnemyGunner";
            naveInstanciada.GetComponent<ClaseMele>().secondTag = "Target1";
        }
        else
        {
            naveInstanciada.GetComponent<ClaseMele>().counterTag = "Gunner";
            naveInstanciada.GetComponent<ClaseMele>().secondTag = "Player";
        }
    }

    public void CallDefender(int equipo)
    {
        GameObject naveInstanciada = Instantiate(DefenderShipPrefab, transform.position, transform.rotation) as GameObject;
        naveInstanciada.GetComponent<ClaseTorre>().vigilanceSpot = lineaMedia;
        naveInstanciada.GetComponent<ClaseTorre>().scapeWay = scapeWayTransform;

        if (equipo == 1)
        {
            naveInstanciada.GetComponent<ClaseTorre>().counterTag = "EnemyAssassin";
            naveInstanciada.GetComponent<ClaseTorre>().secondTag = "Target1";
        }
        else
        {
            naveInstanciada.GetComponent<ClaseTorre>().counterTag = "Assassin";
            naveInstanciada.GetComponent<ClaseTorre>().secondTag = "Player";
        }
    }

}
