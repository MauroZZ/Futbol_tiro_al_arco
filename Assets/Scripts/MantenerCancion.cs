using UnityEngine;

public class MantenerCancion : MonoBehaviour
{
    private static MantenerCancion instancia;
    private AudioSource audioSource;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            if (audioSource != null && !audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DetenerMusica()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void DestruirMusica()
    {
        Destroy(gameObject);
        instancia = null;
    }

    public static MantenerCancion Instance()
    {
        return instancia;
    }
}
