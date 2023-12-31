using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    public int newdifficulty;
    public TextMeshProUGUI text;
    public string newtext;
    public Color newColor;
    // Start is called before the first frame update
    private void Start()
    {
        ScoreManager.Score = 0;
    }
    public void OnPress()
    {
        if (Difficulty.difficulty == newdifficulty)
        {
            SceneManager.LoadScene("Intro");
        }
        else
        {
            Difficulty.difficulty = newdifficulty;
            text.text = newtext;
            text.color = newColor;
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
