using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class arco_move : MonoBehaviour // Asegúrate de que el nombre de la clase coincide con el nombre del archivo del script
{
    public float moveSpeed = 1f; // Velocidad del movimiento del arco
    public float moveRange = 2f; // Rango máximo de desplazamiento desde la posición inicial (ej. 2 unidades a cada lado)
    public float minXPosition = -5f; // Límite X izquierdo de la cancha
    public float maxXPosition = 5f;  // Límite X derecho de la cancha

    private Vector3 initialPosition; // Posición inicial del arco
    private bool moveGoalEnabled = false; // Controla si el arco se mueve, conectado al Toggle del menú

    void Start()
    {
        initialPosition = transform.position; // Guarda la posición inicial del arco
    }

    void Update()
    {
 
        if (moveGoalEnabled)
        {
            Debug.Log("Arco se está moviendo. Tiempo: " + Time.time); // Agrega esta línea
            float newX = initialPosition.x + Mathf.Sin(Time.time * moveSpeed) * moveRange;
            newX = Mathf.Clamp(newX, minXPosition, maxXPosition);
            transform.position = new Vector3(newX, initialPosition.y, initialPosition.z);
        }
    }

    // Este método será llamado desde el Toggle del menú de UI
    public void SetMoveGoal(bool enabled)
    {
        moveGoalEnabled = enabled;
        // Opcional: Si quieres que el arco regrese a su posición central cuando se desactiva
        if (!enabled)
        {
            transform.position = initialPosition;
        }
    }

}
