using UnityEngine;

public class MusicaManager : MonoBehaviour
{
    public AudioSource musicaFondo;
    public static MusicaManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if (musicaFondo != null)
                musicaFondo.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CambiarVolumen(float volumen)
    {
        if (musicaFondo != null)
            musicaFondo.volume = volumen;
    }
}
