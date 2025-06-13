using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorGol : MonoBehaviour
{
    public int golesRequeridos = 3;
    private int goles = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            goles++;
            Debug.Log("¡GOL! Total: " + goles);

            if (goles >= golesRequeridos)
            {
                Debug.Log("🎉 ¡GANASTE! Has anotado 3 goles.");
                // Aquí puedes activar partículas, sonidos, UI final, etc.
            }

            // Opcional: reiniciar la pelota
            ControlPelota controlPelota = other.GetComponent<ControlPelota>();
            if (controlPelota != null)
            {
                controlPelota.ReiniciarPelota();
            }
        }

    }
}
