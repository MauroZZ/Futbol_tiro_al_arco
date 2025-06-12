using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoMovimiento : MonoBehaviour
{
    public float velocidad = 5f;     // Velocidad del movimiento oscilante
    public float rango = 20f;         // Distancia m�xima adelante y atr�s
    public bool mover = false;       // Activar o desactivar el movimiento

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (mover)
        {
            float desplazamiento = Mathf.Sin(Time.time * velocidad) * rango;
            transform.position = posicionInicial + new Vector3(0, 0, desplazamiento); // Movimiento en Z
        }
    }
}