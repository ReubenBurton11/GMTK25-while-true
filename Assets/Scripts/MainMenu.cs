using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Player.instance.ClearDraggables();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
