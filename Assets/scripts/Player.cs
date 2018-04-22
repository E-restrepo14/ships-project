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
    public int life;
    [SerializeField]
    private GameObject Escudo;
    


    void Awake()
	{
		rgbdy = GetComponent<Rigidbody> ();
		mCam = Camera.main;
	}

    void Update()
    {
        VerifyPos();

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


        float translation = Input.GetAxis("Vertical") * speed;
        float htranslation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        htranslation *= Time.deltaTime;
        transform.Translate(htranslation,0, translation);

    }

    public void avanzar()
    {
        estaavanzando = true;
    }
    public void retroceder()
    {
        estaretrocediendo = true;
    }
    public void irderecha()
    {
        vaaladerecha = true;
    }
    public void irizquierda()
    {
        vaalaizquierda = true;
    }

    public void noavanzar()
    {
        estaavanzando = false;
    }
    public void noretroceder()
    {
        estaretrocediendo = false;
    }
    public void noirderecha()
    {
        vaaladerecha = false;
    }
    public void noirizquierda()
    {
        vaalaizquierda = false;
    }

    public IEnumerator Perderunavida(int life)
    {
        life--;
        gameObject.tag = "Untagged";
        Escudo.SetActive(false);
        yield return new WaitForSeconds(5);
        gameObject.tag = "Player";
        Escudo.SetActive(true);

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
