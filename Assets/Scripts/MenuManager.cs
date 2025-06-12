using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject panelPrincipal;
    public GameObject panelOpciones;
    public GameObject panelDescripcion;
    public AudioSource musicaFondo;

    public TMP_InputField inputNombre;
    public Toggle toggleDificultad;
    public Slider sliderVolumen;

    // Variables globales (estáticas)
    public static string nombreJugador = "";
    public static bool modoDificil = false;
    public static float volumenMusica = 1f;

    void Start()
    {
        // Solo mostrar el panel principal al inicio
        MostrarPanelPrincipal();
        musicaFondo.volume = sliderVolumen.value;

        sliderVolumen.onValueChanged.AddListener(delegate {
            CambiarVolumen();
        });
    }

    public void MostrarPanelPrincipal()
    {
        panelPrincipal.SetActive(true);
        panelOpciones.SetActive(false);
        panelDescripcion.SetActive(false);
    }

    public void MostrarPanelOpciones()
    {
        panelPrincipal.SetActive(false);
        panelOpciones.SetActive(true);
        panelDescripcion.SetActive(false);
    }

    public void MostrarPanelDescripcion()
    {
        panelPrincipal.SetActive(false);
        panelOpciones.SetActive(false);
        panelDescripcion.SetActive(true);
    }

    public void Jugar()
    {
        nombreJugador = inputNombre.text;
        modoDificil = toggleDificultad.isOn;
        volumenMusica = sliderVolumen.value;

        SceneManager.LoadScene("Juego"); // Asegúrate que el nombre coincida con tu escena
    }

    public void CambiarVolumen()
    {
        musicaFondo.volume = sliderVolumen.value;
        volumenMusica = sliderVolumen.value;
    }
}
