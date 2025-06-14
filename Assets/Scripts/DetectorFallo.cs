using UnityEngine;

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
                detectorGol.DescontarGol(); // Llama a un nuevo método que restará el gol
            }

            // Reiniciar la pelota
            ControlPelota controlPelota = other.GetComponent<ControlPelota>();
            if (controlPelota != null)
                controlPelota.ReiniciarPelota();
        }
    }
}
