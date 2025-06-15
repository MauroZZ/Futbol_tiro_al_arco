using UnityEngine;
using TMPro;

public class DetectorGol : MonoBehaviour
{
    public int golesRequeridos = 3;
    private int goles = 0;

    public GameObject panelVictoria;
    public TextMeshProUGUI textoNombreJugador;
    public TextMeshProUGUI textoContadorGoles; // <- Contador en pantalla

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip sonidoGol;

    [Header("Partículas")]
    public GameObject fuegosArtificiales;

    void Start()
    {
        ActualizarContador(); // Inicializa el contador en pantalla
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            goles++;
            Debug.Log("¡GOL! Total: " + goles);

            // Sonido de gol
            if (audioSource != null && sonidoGol != null)
            {
                audioSource.PlayOneShot(sonidoGol);
            }

            ActualizarContador();

            if (goles >= golesRequeridos)
            {
                Debug.Log("¡GANASTE! Has anotado 3 goles.");

                // Mostrar panel de victoria
                panelVictoria.SetActive(true);

                // Mostrar nombre del jugador
                string nombreJugador = MenuManager.nombreJugador;
                textoNombreJugador.text = "¡Bien hecho, " + nombreJugador + "!";

                // Detener música si existe MusicaManager
                if (MusicaManager.instance != null)
                {
                    MusicaManager.instance.DetenerMusica();
                }

                // Activar fuegos artificiales
                if (fuegosArtificiales != null)
                {
                    fuegosArtificiales.SetActive(true);
                }

                // Desactivar la pelota
                other.gameObject.SetActive(false);
            }
            else
            {
                // Reiniciar pelota solo si aún no se gana
                ControlPelota controlPelota = other.GetComponent<ControlPelota>();
                if (controlPelota != null)
                {
                    controlPelota.ReiniciarPelota();
                }
            }
        }
    }

    public void DescontarGol()
    {
        goles = Mathf.Max(0, goles - 1);
        Debug.Log("Gol descontado. Goles actuales: " + goles);
        ActualizarContador();
    }

    private void ActualizarContador()
    {
        if (textoContadorGoles != null)
        {
            textoContadorGoles.text = "Goles: " + goles;
        }
    }
}
