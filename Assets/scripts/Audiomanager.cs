using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{

    public static Audiomanager Instance;
    [SerializeField]
    private GameObject explosionParticle;
    [SerializeField]
    private AudioClip impactSound;
    [SerializeField]
    private AudioClip music;

    public AudioSource audioSource;
    public AudioSource musicSource;

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
        musicSource = GetComponent<AudioSource>();
        musicSource.PlayOneShot(music, 0.5f);
    }

    public void Explotar (GameObject go)
    {
        GameObject explosion = Instantiate(explosionParticle, go.transform.position, go.transform.rotation) as GameObject;
        Sonar(impactSound, Random.Range(0.5f, 0.2f));
        Destroy(explosion, 2);
    }

    public void Sonar (AudioClip privateaudioclip, float vol)
    {
        audioSource.PlayOneShot (privateaudioclip, vol);
    }
}
