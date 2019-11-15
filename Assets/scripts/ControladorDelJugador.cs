using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDelJugador : MonoBehaviour
{
    public float velocidad;
    int puntuacion;
    Rigidbody rb;

   public Text puntuacion;
   public Text Findeljuego;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        marcador.text =”Puntos:”+ puntuacion
        ActualizarMarcador();
        findejuego.gameObject.SetActive(false);
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
        puntuacion = puntuacion + 1;
        ActualizarMarcador();
        if (puntuacion >= 13) //El juego finaliza a los 13 puntos
        {
            findejuego.gameObject.SetActive(true);
        }
    }

    void ActualizarMarcador()
    {
        marcador.text = "Puntos: " + puntuacion;
    }
}