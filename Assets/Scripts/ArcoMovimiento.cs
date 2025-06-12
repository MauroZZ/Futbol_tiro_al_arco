using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoMovimiento : MonoBehaviour
{
    public float velocidad = 5f;     // Velocidad del movimiento oscilante
    public float rango = 20f;        // Distancia máxima adelante y atrás

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Leer el valor desde el MenuManager
        bool mover = MenuManager.modoDificil;

        if (mover)
        {
            float desplazamiento = Mathf.Sin(Time.time * velocidad) * rango;
            transform.position = posicionInicial + new Vector3(0, 0, desplazamiento); // Movimiento en Z
        }
        else
        {
            transform.position = posicionInicial; // Mantener quieto si no se mueve
        }
    }
}
