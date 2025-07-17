using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    public void ClickPlay()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Asteroids"); //Name of Gameplayscenbe
    }

    public void ClickQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
