using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateManager : MonoBehaviour
{
    //este codigo le asigna el tag, el tag del enemigo principal de la nave que va a instanciar, tambien el punto de escape y el punto de formacion
    //para que ente script funcione se le deben asignar variables desde el inspector, para que los soldados sean aliados se debe dar el argumento "equipo" = 1
    // "Target1" y "Player" son los tag para identificar los bosses y al player.

    [SerializeField]
    private GameObject gunnerShipPrefab;
    [SerializeField]
    private GameObject assassinShipPrefab;
    [SerializeField]
    private GameObject DefenderShipPrefab;

    public GameObject assassinClone;
    public GameObject gunnerClone;
    public GameObject defenderClone;

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

    public void RetractGunner()
    {
        gunnerClone.GetComponent<ClaseAsedio>().seRetira = true;
    }

    public void RetractAssassin()
    {
        assassinClone.GetComponent<ClaseMele>().seRetira = true;
    }

    public void RetractDefender()
    {
        defenderClone.GetComponent<ClaseTorre>().seRetira = true;
    }

    public void CallGunner(int equipo)
    {
        gunnerClone = Instantiate(gunnerShipPrefab, transform.position, transform.rotation) as GameObject;
        gunnerClone.GetComponent<ClaseAsedio>().vigilanceSpot = lineaFrontal;
        gunnerClone.GetComponent<ClaseAsedio>().scapeWay = scapeWayTransform;

        if (equipo == 1)
        {
            gunnerClone.tag = "Gunner";
            gunnerClone.GetComponent<ClaseAsedio>().counterTag = "EnemyDefender";
            gunnerClone.GetComponent<ClaseAsedio>().secondTag = "Target1";
        }
        else
        {
            gunnerClone.tag = "EnemyGunner";
            gunnerClone.GetComponent<ClaseAsedio>().counterTag = "Defender";
            gunnerClone.GetComponent<ClaseAsedio>().secondTag = "Player";
        }
    }

    public void CallAssassin(int equipo)
    {
        assassinClone = Instantiate(assassinShipPrefab, transform.position, transform.rotation) as GameObject;
        assassinClone.GetComponent<ClaseMele>().vigilanceSpot = lineaDefensiva;
        assassinClone.GetComponent<ClaseMele>().scapeWay = scapeWayTransform;

        if (equipo == 1)
        {
            assassinClone.tag = "Assassin";
            assassinClone.GetComponent<ClaseMele>().counterTag = "EnemyGunner";
            assassinClone.GetComponent<ClaseMele>().secondTag = "Target1";
        }
        else
        {
            assassinClone.tag = "EnemyAssassin";
            assassinClone.GetComponent<ClaseMele>().counterTag = "Gunner";
            assassinClone.GetComponent<ClaseMele>().secondTag = "Player";
        }
    }

    public void CallDefender(int equipo)
    {
        defenderClone = Instantiate(DefenderShipPrefab, transform.position, transform.rotation) as GameObject;
        defenderClone.GetComponent<ClaseTorre>().vigilanceSpot = lineaMedia;
        defenderClone.GetComponent<ClaseTorre>().scapeWay = scapeWayTransform;

        if (equipo == 1)
        {
            defenderClone.tag = "Defender";
            defenderClone.GetComponent<ClaseTorre>().counterTag = "EnemyAssassin";
            defenderClone.GetComponent<ClaseTorre>().secondTag = "Target1";
        }
        else
        {
            defenderClone.tag = "EnemyDefender";
            defenderClone.GetComponent<ClaseTorre>().counterTag = "Assassin";
            defenderClone.GetComponent<ClaseTorre>().secondTag = "Player";
        }
    }

}
