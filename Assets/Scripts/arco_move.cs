using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class arco_move : MonoBehaviour // Aseg�rate de que el nombre de la clase coincide con el nombre del archivo del script
{
    public float moveSpeed = 1f; // Velocidad del movimiento del arco
    public float moveRange = 2f; // Rango m�ximo de desplazamiento desde la posici�n inicial (ej. 2 unidades a cada lado)
    public float minXPosition = -5f; // L�mite X izquierdo de la cancha
    public float maxXPosition = 5f;  // L�mite X derecho de la cancha

    private Vector3 initialPosition; // Posici�n inicial del arco
    private bool moveGoalEnabled = false; // Controla si el arco se mueve, conectado al Toggle del men�

    void Start()
    {
        initialPosition = transform.position; // Guarda la posici�n inicial del arco
    }

    void Update()
    {
 
        if (moveGoalEnabled)
        {
            Debug.Log("Arco se est� moviendo. Tiempo: " + Time.time); // Agrega esta l�nea
            float newX = initialPosition.x + Mathf.Sin(Time.time * moveSpeed) * moveRange;
            newX = Mathf.Clamp(newX, minXPosition, maxXPosition);
            transform.position = new Vector3(newX, initialPosition.y, initialPosition.z);
        }
    }

    // Este m�todo ser� llamado desde el Toggle del men� de UI
    public void SetMoveGoal(bool enabled)
    {
        moveGoalEnabled = enabled;
        // Opcional: Si quieres que el arco regrese a su posici�n central cuando se desactiva
        if (!enabled)
        {
            transform.position = initialPosition;
        }
    }

}
