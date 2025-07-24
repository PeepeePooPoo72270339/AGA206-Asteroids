using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text ScoreTextBox, HighScoreTextBox;

    public GameObject GameoverPanel;

    public GameObject Celebrate;
    void Start()
    {
        Hide();
    }

    public void Hide()
    {
        GameoverPanel.SetActive(false);
    }

    public void Show(bool celebrateHighScore, int score, int highscore)
    {
        ScoreTextBox.text = score.ToString();
        HighScoreTextBox.text = highscore.ToString();
        GameoverPanel.SetActive(true);
        Celebrate.SetActive(celebrateHighScore);

    }

    public void ClickPlayAgain()
    {
        SceneManager.LoadScene("Asteroids");
    }

    public void ClickMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");

    }

}
