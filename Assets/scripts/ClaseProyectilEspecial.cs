using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseProyectilEspecial : MonoBehaviour
{





    public string targetTag;
    public string safeTag;
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
            //en esta linea me tengo que encargar de llegar al subproceso (que aun no he creado) de rebajar vida... que tendran tanto el player como la clase reina
            if (other.GetComponent<Player>() != null)
            {
                other.GetComponent<Player>().StartCoroutine("BajarVida");
            }
            if (other.GetComponent<ClaseQueen>() != null)
            {
                other.GetComponent<ClaseQueen>().StartCoroutine("BajarVida");
            }
            Audiomanager.Instance.Explotar(gameObject);
            Destroy(gameObject);
        }
        else
        {
            if (other.gameObject.CompareTag(safeTag))
            {

            }
            else
            {
                Destroy(other.gameObject);
                Audiomanager.Instance.Explotar(gameObject);
                //la bala de esta nave reina solo se destruye si golpea (al prota, o a la reina... dependiendo el caso) y desintera balas en su camino...
            }
        }
    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 7);
    }

}
