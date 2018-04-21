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
        if (other.gameObject.CompareTag(targetTag) || other.gameObject.CompareTag(secondTargetTag))
        {
            Destroy(other.gameObject);
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation) as GameObject;
            Destroy(explosion, 2);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*4);
    }

}
