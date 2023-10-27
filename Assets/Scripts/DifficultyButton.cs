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
}
