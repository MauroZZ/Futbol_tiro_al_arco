using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectorGol : MonoBehaviour
{
    public int golesRequeridos = 3;
    private int goles = 0;

    [Header("UI Victoria")]
    public GameObject panelVictoria;
    public TextMeshProUGUI textoNombreJugador;

    [Header("Audio")]
    public AudioSource audioSource;     // Asigna un AudioSource en el inspector
    public AudioClip sonidoGol;         // Clip de sonido para cada gol
    public AudioClip sonidoFuegosArtificiales; // Sonido de fuegos artificiales al ganar

    [Header("Partículas")]
    public GameObject fuegosArtificiales;  // GameObject con ParticleSystem (desactivado al inicio)
    public TextMeshProUGUI textoContadorGoles;
    void Start()
    {
        ActualizarContadorGoles();
    }
    private void ActualizarContadorGoles()
    {
        textoContadorGoles.text = "Goles: " + goles + " / " + golesRequeridos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Pelota")) return;

        // ➜ Incrementar y mostrar gol
        goles++;
        ActualizarContadorGoles();
        Debug.Log("¡GOL! Total: " + goles);

        // ➜ Reproducir sonido de gol
        if (audioSource != null && sonidoGol != null)
            audioSource.PlayOneShot(sonidoGol);

        // ➜ ¿Ganó el jugador?
        if (goles >= golesRequeridos)
        {
            Debug.Log("¡GANASTE! Has anotado 3 goles.");

            // Mostrar panel de victoria
            panelVictoria.SetActive(true);

            // Personalizar mensaje con el nombre del jugador
            textoNombreJugador.text = "¡Bien hecho, " + MenuManager.nombreJugador + "!";

            // Activar fuegos artificiales
            if (fuegosArtificiales != null)
            {
                fuegosArtificiales.SetActive(true);
                var ps = fuegosArtificiales.GetComponent<ParticleSystem>();
                if (ps != null) ps.Play();
            }
            // Sonido de fuegos artificiales
            if (audioSource != null && sonidoFuegosArtificiales != null)
                audioSource.PlayOneShot(sonidoFuegosArtificiales);
            // Desactivar la pelota para que no bloquee la UI
            other.gameObject.SetActive(false);
            return; // Ya no es necesario reiniciar pelota
        }

        // ➜ Si aún no gana, reiniciar la pelota
        ControlPelota controlPelota = other.GetComponent<ControlPelota>();
        if (controlPelota != null)
            controlPelota.ReiniciarPelota();
    }
}
