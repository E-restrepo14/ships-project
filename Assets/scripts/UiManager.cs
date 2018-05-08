using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public GameObject[] lifes;
    


    public GameObject personaje;
    public GameObject bicicleta;


    [SerializeField]
    private GameObject winSprite;
    [SerializeField]
    private GameObject looseSprite;
    [SerializeField]
    private GameObject backGround;

    public static UiManager Instance;
    public AudioSource source;
    public bool estaPausado;

    // este como varios otros singletons en la escena. almacenan variables que otros scripts toman y modifican para modificar las funciones de otros script que toman estas variables como argumentos
    private void Awake()
    {
        source = GetComponent<AudioSource>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //==================================================

        // todos estos son subprocesos que se manejan desde botones y sliders en el hud unicamente

    public void Ganar()
    {
        MostrarCosa(winSprite);
        MostrarCosa(backGround);
        estaPausado = true;
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public void Perder()
    {
        MostrarCosa(looseSprite);
        MostrarCosa(backGround);
        estaPausado = true;
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.fixedTime;
    }

    public void Pausar()
    {
        
        estaPausado = !estaPausado;

        if (estaPausado == true)
        {
            Time.timeScale = 0.0F;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public void ChangeSfxVolume(GameObject slider)
    {
        float newVolume = slider.GetComponent<Slider>().value;
        Audiomanager.Instance.audioSource.volume = newVolume;
    }

    public void ChangeMusicVolume(GameObject slider)
    {
        float newVolume = slider.GetComponent<Slider>().value;
        Audiomanager.Instance.musicSource.volume = newVolume;
    }


    public void MostrarCosa(GameObject cosa)
    {
        cosa.SetActive (true);
    }
    public void OcultarCosa(GameObject cosa)
    {
        cosa.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }

}

