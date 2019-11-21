using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SalirDelJuego : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //sale del juego. No lo pausa.
        }
    }
}

public class ControladorDelJugador : MonoBehaviour
{
    public float velocidad;
    int contador;
    int goldpoint;
    int item2;

    Rigidbody rb;

   public Text marcador;
   public Text Findeljuego;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Findeljuego.gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f,
        movimientoVertical);
        rb.AddForce(movimiento * velocidad);
    }
    public void OnTriggerEnter(Collider other) //Collider es el objeto con el que ha colisionado
    {
        if (other.tag == "+1")
        {
            Destroy(other.gameObject);
            contador = contador + 1;

        }


        else if (other.tag == "+2")
        {
            Destroy(other.gameObject);
            contador = contador + 2;
            goldpoint = goldpoint + 1;
        }

       else if (other.tag == "-1")
        {
            Destroy(other.gameObject);
            contador = contador +1;
            item2 = item2 - 1;
        }

        ActualizarMarcador();

        if (contador >=9 && goldpoint >=3 )
        {
            Findeljuego.gameObject.SetActive(true); //finaliza el juego
            Time.timeScale = 0; //cogela  al finalizar
        }

    }

    void ActualizarMarcador()
    {
        marcador.text = "Puntos: " + contador;
    }
}
