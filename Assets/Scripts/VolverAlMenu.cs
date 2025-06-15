using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAlMenu : MonoBehaviour
{
    public void IrAlMenu()
    {
        if (MusicaManager.instance != null)
        {
            MusicaManager.instance.DetenerMusica();
            MusicaManager.instance.DestruirMusica();
        }

        SceneManager.LoadScene("MenuPrincipal");
    }

    public void ReintentarJuego()
    {
        SceneManager.LoadScene("Juego");
    }
}
