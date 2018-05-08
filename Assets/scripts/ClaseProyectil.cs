using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseProyectil : MonoBehaviour
{
    //esta clase le ordena a la particula avanzar hacia adelante, y le dá ciertas ordenes dependiendo con que tag de collider se encuentre. 
    //tags que son asignados desde el mismo gameobject que ordena instanciar (este gameobject propietario de este script)

    //en caso de querer crearle una variable nueva a esta clase... se le debe asignar desde todos las clases que instancian un gameobject (con este script como componente) 

    public string targetTag;
    public string secondTargetTag;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
        else
        if (other.gameObject.CompareTag(secondTargetTag))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<Player>().StartCoroutine("BajarVida");
            }
            Audiomanager.Instance.Explotar(gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(targetTag))
        {
            Destroy(other.gameObject);
            Audiomanager.Instance.Explotar(gameObject);
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*4);
    }

}
