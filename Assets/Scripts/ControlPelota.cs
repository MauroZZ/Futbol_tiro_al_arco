using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPelota : MonoBehaviour
{
    public float fuerzaMin = 5f;
    public float fuerzaMax = 100f;
    public float tiempoMaxCarga = 3f;
    public float sensibilidad = 100f;
    public Transform camara;

    private Rigidbody rb;
    private float tiempoCarga = 0f;
    private bool disparada = false;
    private float rotY = 0f;
    public Transform arco;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip sonidoDisparo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ParedTrasera"))
        {
            ReiniciarPelota();
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 direccionAlArco = arco.position - transform.position;
        direccionAlArco.y = 0f;

        Quaternion rotacionInicial = Quaternion.LookRotation(direccionAlArco);
        rotY = rotacionInicial.eulerAngles.y;

        camara.rotation = Quaternion.Euler(10f, rotY, 0f);
        camara.position = transform.position + Quaternion.Euler(0f, rotY, 0f) * new Vector3(0f, 1.5f, -10f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 1️⃣ Liberar el cursor para poder usar la UI del menú
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // 2️⃣ (opcional) Asegura que el tiempo esté corriendo por si luego pausas con Time.timeScale
            Time.timeScale = 1f;

            // 3️⃣ Cargar el menú
            SceneManager.LoadScene("MenuPrincipal");
        }

        if (!disparada)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
            rotY += mouseX;

            camara.rotation = Quaternion.Euler(10f, rotY, 0f);
            camara.position = transform.position + Quaternion.Euler(0f, rotY, 0f) * new Vector3(0f, 1.5f, -10f);
        }

        if (Input.GetKey(KeyCode.Space) && !disparada)
        {
            tiempoCarga += Time.deltaTime;
            tiempoCarga = Mathf.Clamp(tiempoCarga, 0f, tiempoMaxCarga);
        }

        if (Input.GetKeyUp(KeyCode.Space) && !disparada)
        {
            float fuerza = Mathf.Lerp(fuerzaMin, fuerzaMax, tiempoCarga / tiempoMaxCarga);
            rb.AddForce(camara.forward * fuerza, ForceMode.Impulse);
            disparada = true;

            // Reproducir sonido de disparo
            if (audioSource != null && sonidoDisparo != null)
                audioSource.PlayOneShot(sonidoDisparo);

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
