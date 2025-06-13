using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPelota : MonoBehaviour
{
    public float fuerzaMin = 5f;
    public float fuerzaMax = 20f;
    public float tiempoMaxCarga = 3f;
    public float sensibilidad = 100f;
    public Transform camara;

    private Rigidbody rb;
    private float tiempoCarga = 0f;
    private bool disparada = false;
    private float rotY = 0f;
    public Transform arco;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Calcula la dirección horizontal desde la pelota hacia el arco
        Vector3 direccionAlArco = arco.position - transform.position;
        direccionAlArco.y = 0f; // ignorar diferencia en altura

        // Convertimos esa dirección en un ángulo de rotación Y
        Quaternion rotacionInicial = Quaternion.LookRotation(direccionAlArco);
        rotY = rotacionInicial.eulerAngles.y;

        // Aplicamos rotación y posición inicial a la cámara
        camara.rotation = Quaternion.Euler(10f, rotY, 0f);
        camara.position = transform.position + Quaternion.Euler(0f, rotY, 0f) * new Vector3(0f, 1.5f, -10f);
    }


    void Update()
    {
        if (!disparada)
        {
            // Rotación solo horizontal (izquierda/derecha)
            float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
            rotY += mouseX;

            camara.rotation = Quaternion.Euler(10f, rotY, 0f);  // fija inclinación vertical
            camara.position = transform.position + Quaternion.Euler(0f, rotY, 0f) * new Vector3(0f, 1.5f, -10f);
        }

        // Carga de fuerza
        if (Input.GetKey(KeyCode.Space) && !disparada)
        {
            tiempoCarga += Time.deltaTime;
            tiempoCarga = Mathf.Clamp(tiempoCarga, 0f, tiempoMaxCarga);
        }

        // Disparo
        if (Input.GetKeyUp(KeyCode.Space) && !disparada)
        {
            float fuerza = Mathf.Lerp(fuerzaMin, fuerzaMax, tiempoCarga / tiempoMaxCarga);
            rb.AddForce(camara.forward * fuerza, ForceMode.Impulse);
            disparada = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void ReiniciarPelota()
    {
        tiempoCarga = 0f;
        disparada = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = new Vector3(0f, 0.5f, 0f);

        Vector3 direccionAlArco = arco.position - transform.position;
        direccionAlArco.y = 0f;
        Quaternion rotacionInicial = Quaternion.LookRotation(direccionAlArco);
        rotY = rotacionInicial.eulerAngles.y;

        camara.rotation = Quaternion.Euler(10f, rotY, 0f);
        camara.position = transform.position + Quaternion.Euler(0f, rotY, 0f) * new Vector3(0f, 1.5f, -10f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
