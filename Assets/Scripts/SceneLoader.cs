using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnBotonPlay()
    {
        SceneManager.LoadScene("SetupGame");
    }
    public void PantallaJugadores()
    {
        if (GameManager.Instance.jugadores.Count == 0)
        {
            SceneManager.LoadScene("PlayerNames");
        }
        else
        {
            SceneManager.LoadScene("ShowRoles");
        }
    }
    public void MostrarRoles()
    {
        SceneManager.LoadScene("ShowRoles");
    }
    public void VolverMenu()
    {
        Destroy(GameManager.Instance.gameObject);
        SceneManager.LoadScene("SetupGame");
    }
}
