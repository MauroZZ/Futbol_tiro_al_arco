using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectorGol : MonoBehaviour
{
    public int golesRequeridos = 3;
    private int goles = 0;

    public GameObject panelVictoria;
    public TextMeshProUGUI textoNombreJugador;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            goles++;
            Debug.Log("¡GOL! Total: " + goles);

            if (goles >= golesRequeridos)
            {
                Debug.Log("¡GANASTE! Has anotado 3 goles.");

                panelVictoria.SetActive(true);

                string nombreJugador = MenuManager.nombreJugador;
                textoNombreJugador.text = "¡Bien hecho, " + nombreJugador + "!";
            }

            ControlPelota controlPelota = other.GetComponent<ControlPelota>();
            if (controlPelota != null)
            {
                controlPelota.ReiniciarPelota();
            }
        }

    }
}
