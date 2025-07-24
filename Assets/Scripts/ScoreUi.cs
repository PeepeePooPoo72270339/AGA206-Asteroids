using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUi : MonoBehaviour
{
    public TMP_Text ScoreBoxText;
    private Spaceship ship;

    private void Start()
    {
        ship = FindFirstObjectByType<Spaceship>();
        
    }

    private void Update()
    {
        if(ship != null)
        {
            ScoreBoxText.text = "Score:  " + ship.Score.ToString();
        }
    }
}
