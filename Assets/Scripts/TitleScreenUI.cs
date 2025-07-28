using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{   //Load and quit game when buttons are clicked
    public void ClickPlay()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Asteroids"); //Name of Gameplay scene
    }

    public void ClickQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
