using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorGol : MonoBehaviour
{
    public int goles = 0;
    public GameObject panelVictoria;
    public TMPro.TextMeshProUGUI textoJugador;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            goles++;
            if (goles >= 3)
            {
                panelVictoria.SetActive(true);
                // Mostrar nombre jugador si está en PlayerPrefs
                if (PlayerPrefs.HasKey("NombreJugador"))
                    textoJugador.text = "¡Ganaste, " + PlayerPrefs.GetString("NombreJugador") + "!";
            }
        }
    }
}

