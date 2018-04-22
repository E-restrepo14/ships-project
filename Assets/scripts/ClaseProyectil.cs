using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClaseProyectil : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionParticle;
    public string targetTag;
    public string secondTargetTag;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(secondTargetTag))
        {
            //Destroy(other.gameObject);
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
