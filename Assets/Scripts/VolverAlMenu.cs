using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAlMenu : MonoBehaviour
{
    public void IrAlMenu()
    {
        // Detener y destruir la música persistente si existe
        if (MusicaManager.instance != null && MusicaManager.instance.musicaFondo != null)
        {
            MusicaManager.instance.musicaFondo.Stop();
            Destroy(MusicaManager.instance.gameObject);
        }

        SceneManager.LoadScene("MenuPrincipal");
    }

    public void ReintentarJuego()
    {
        SceneManager.LoadScene("Juego");
    }
}