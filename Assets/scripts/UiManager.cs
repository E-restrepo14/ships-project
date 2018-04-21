using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject skin2;
    [SerializeField]
    private GameObject skin3;
    [SerializeField]
    private GameObject skin4;

    
    [SerializeField]
    private GameObject bike2;
    [SerializeField]
    private GameObject bike3;
    [SerializeField]
    private GameObject bike4;


    public GameObject personaje;
    public GameObject bicicleta;


    [SerializeField]
    private GameObject winSprite;
    [SerializeField]
    private GameObject looseSprite;
    [SerializeField]
    private GameObject backGround;
    public static UiManager Instance;
    public bool estaPausado;

    // este como varios otros singletons en la escena. almacenan variables que otros scripts toman y modifican para modificar las funciones de otros script que toman estas variables como argumentos
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
    //==================================================

        // todos estos son subprocesos que se manejan desde botones y sliders en el hud unicamente

    public void Ganar()
    {       
        /*
        MostrarCosa(winSprite);
        MostrarCosa(backGround);
        estaPausado = true;
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;*/
    }

    public void Perder()
    {
        /*MostrarCosa(looseSprite);
        MostrarCosa(backGround);
        estaPausado = true;
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.fixedTime;*/
    }

    public void Pausar()
    {
        /*
        estaPausado = !estaPausado;

        if (estaPausado == true)
        {
            Time.timeScale = 0.0F;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        Time.fixedDeltaTime = 0.02F * Time.timeScale;*/
    }

    public void CambiarVolumen(GameObject slider)
    {
        /*float volume = slider.GetComponent<Slider>().value;
        GameManager.Instance.source.volume = volume;*/
    }

    public void CambiarPersonaje(Material NewMaterial)
    {
        /*personaje.GetComponent<Renderer>().material = NewMaterial; */
    }

    public void CambiarBicicleta(Material NewMaterial)
    {
        /*bicicleta.GetComponent<Renderer>().material = NewMaterial; */
    }

    public void Desbloquearnivel()
    {/*
        if (GameManager.Instance.levelnum == 1)
        {
            GameManager.Instance.botonNivel2.GetComponent<Button>().interactable = true;
            skin2.GetComponent<Button>().interactable = true;
            bike2.GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.levelnum == 2)
        {
            GameManager.Instance.botonNivel3.GetComponent<Button>().interactable = true;
            skin3.GetComponent<Button>().interactable = true;
            bike3.GetComponent<Button>().interactable = true;
        }
        if (GameManager.Instance.levelnum == 3)
        {
            skin4.GetComponent<Button>().interactable = true;
            bike4.GetComponent<Button>().interactable = true;
        }
        */
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

