using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalScore : MonoBehaviour
{
    float multiplier;
    public TextMeshProUGUI rating;
    public TextMeshProUGUI score;
    public string SText;
    public Color SColor;
    public string AText;
    public Color AColor;
    public string BText;
    public Color BColor;
    public string CText;
    public Color CColor;
    public string FText;
    public Color FColor;
    // Start is called before the first frame update
    public void Start()
    {
        if (Difficulty.difficulty == 1)
        {
            multiplier= 1;
        }
        else if (Difficulty.difficulty == 2)
        {
            multiplier= 1.25f;
        }
        else if (Difficulty.difficulty == 3)
        {
            multiplier= 1.5f;
        }
        else
        {
            multiplier= 1;
        }
        ScoreManager.Score = ScoreManager.Score * multiplier;
        score.text = (ScoreManager.Score +"points");
        if (ScoreManager.Score >= 100)
        {
            rating.text = SText;
            rating.color = SColor;
        }
        else if (ScoreManager.Score>=75 && ScoreManager.Score< 100)
        {
            rating.color = AColor;
            rating.text = AText;
        }
        else if (ScoreManager.Score >= 50 && ScoreManager.Score < 75)
        {
            rating.color = BColor;
            rating.text = BText;
        }
        else if (ScoreManager.Score >= 25 && ScoreManager.Score < 50)
        {
            rating.color = CColor;
            rating.text = CText;
        }
        else
        {
            rating.color = FColor;
            rating.text = FText;
        }
    }
    public void OnPlayAgain()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
