using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class DetectorFallo : MonoBehaviour
{
    public DetectorGol detectorGol; // Referencia al script que lleva el conteo de goles

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            Debug.Log("¡Fallaste! Tocaste la pared.");
            if (detectorGol != null)
            {
                Debug.Log("Llamando a DescontarGol");
                detectorGol.DescontarGol();
            }
            else
            {
                Debug.LogWarning("DetectorGol no asignado en DetectorFallo");
            }

            ControlPelota controlPelota = other.GetComponent<ControlPelota>();
            if (controlPelota != null)
                controlPelota.ReiniciarPelota();
        }
    }

}
