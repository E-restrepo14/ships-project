using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	Camera mCam;
	Rigidbody rgbdy;
    public float speed;
	public Vector3 limits;
    public bool estaavanzando;
    public bool estaretrocediendo;
    public bool vaaladerecha;
    public bool vaalaizquierda;
    public bool estaDisparando;
    [HideInInspector]
    public int life;
    [SerializeField]
    private GameObject Escudo;



    public string counterTag;
    public string secondTag;
    [SerializeField]
    private GameObject privateShoot;
    float NextTime = 0;
    //counter deberia haberse llamado tiempo de carga de disparo.
    int counter = 5;


    void Awake()
	{
		rgbdy = GetComponent<Rigidbody> ();
		mCam = Camera.main;
        life = 3;
        counterTag = "EnemyDefender";
        secondTag = "Target1";
    }

    void Update()
    {
        VerifyPos();

        if (estaDisparando == true)
        {
            if (Time.fixedTime > NextTime)
            {
                NextTime = Time.fixedTime + counter;
                GameObject proyectil = Instantiate(privateShoot, transform.position, transform.rotation) as GameObject;
                proyectil.GetComponent<ClaseProyectilEspecial>().targetTag = counterTag;
                proyectil.GetComponent<ClaseProyectilEspecial>().safeTag = gameObject.tag;
                proyectil.GetComponent<ClaseProyectilEspecial>().secondTargetTag = secondTag;
                Destroy(proyectil, 10);
            }
        }

        if (estaavanzando == true)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (estaretrocediendo == true)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (vaaladerecha == true)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (vaalaizquierda == true)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

     

        // este bloque no se me debe olvidar eliminarlo, ya que solo está acá para poder ser testeado
        float translation = Input.GetAxis("Vertical") * speed;
        float htranslation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        htranslation *= Time.deltaTime;
        transform.Translate(htranslation,0, translation);
    }

    

    public void Avanzar()
    {
        estaavanzando = true;
    }
    public void Retroceder()
    {
        estaretrocediendo = true;
    }
    public void Irderecha()
    {
        vaaladerecha = true;
    }
    public void Irizquierda()
    {
        vaalaizquierda = true;
    }
    public void Disparar()
    {
        estaDisparando = true;
    }

    public void Noavanzar()
    {
        estaavanzando = false;
    }
    public void Noretroceder()
    {
        estaretrocediendo = false;
    }
    public void Noirderecha()
    {
        vaaladerecha = false;
    }
    public void Noirizquierda()
    {
        vaalaizquierda = false;
    }
    public void Nodisparar()
    {
        estaDisparando = false;
    }

    public IEnumerator BajarVida()
    {
        if (life >= 1)
        {
            life--;
            UiManager.Instance.OcultarCosa(UiManager.Instance.lifes[life]);
            Escudo.SetActive(true);
            yield return new WaitForSeconds(5);
            Escudo.SetActive(false);
        }
        else
        Destroy(gameObject);
    }




    private void VerifyPos()
    {
        Vector3 p = rgbdy.position;
        float distanceFromCamera = (mCam.transform.position - p).y;

        limits = mCam.ViewportToWorldPoint(new Vector3(1f, 1f, distanceFromCamera));
        limits.x -= transform.localScale.x / 2;
        limits.z -= transform.localScale.z / 2;
        

        //en caso de que la posicion del jugador se salga de los limites puestos por el viewport... estos ifs se encargaran de detener al jugador.
        if (p.x < -limits.x)
        {
            p.x = -limits.x;
            vaalaizquierda = false;
        }
        if (p.x > limits.x)
        {
            p.x = limits.x;
            vaaladerecha = false;
        }
        if (p.z < -limits.z)
        {
            p.z = -limits.z;
            estaretrocediendo = false;
        }
        if (p.z > limits.z)
        {
            p.z = limits.z;
            estaavanzando = false;
        }
        rgbdy.position = p;
    }
}
