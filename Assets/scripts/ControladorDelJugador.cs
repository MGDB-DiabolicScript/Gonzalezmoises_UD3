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
        Destroy(other.gameObject);
        contador = contador + 1;
        ActualizarMarcador();
        if (contador >= 2)
        {
            Findeljuego.gameObject.SetActive(true);
        }

    }

    void ActualizarMarcador()
    {
        marcador.text = "Puntos: " + contador;
    }
}
