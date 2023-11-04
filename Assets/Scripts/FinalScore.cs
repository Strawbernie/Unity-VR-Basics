using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalScore : MonoBehaviour
{
    float multiplier;
    float speedmultiplier;
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
        speedmultiplier = ScoreManager.TimeLeft / 100;
        ScoreManager.Score = ScoreManager.Score * multiplier * speedmultiplier;
        score.text = (ScoreManager.Score +"points");
        if (ScoreManager.Score >= 850)
        {
            rating.text = SText;
            rating.color = SColor;
        }
        else if (ScoreManager.Score>=850 && ScoreManager.Score< 650)
        {
            rating.color = AColor;
            rating.text = AText;
        }
        else if (ScoreManager.Score >= 650 && ScoreManager.Score < 450)
        {
            rating.color = BColor;
            rating.text = BText;
        }
        else if (ScoreManager.Score >= 450 && ScoreManager.Score < 300)
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
