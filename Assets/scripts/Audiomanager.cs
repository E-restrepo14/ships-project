using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{

    /* en este script, me voy a encargar de crear una corutina que reciba como argumento el objeto que se va a explotar... y este al ser llamado. pondra a sonar una explosion 
     * desde el audiosource del gameobject que contienene este script y a la vez instanciará una particula de una explosion en el lugar del "gameobject argumento" listo a trabajar!!!
     */

    public static Audiomanager Instance;
    [SerializeField]
    private GameObject explosionParticle;
    [SerializeField]
    private AudioClip impactSound;
    [SerializeField]
    private AudioSource audioSource;

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

    
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

  

    public void Explotar (GameObject go)
    {
        GameObject explosion = Instantiate(explosionParticle, go.transform.position, go.transform.rotation) as GameObject;
        audioSource.PlayOneShot(impactSound, Random.Range(0.75f,1.0f));
        Destroy(explosion, 2);
    }
}
