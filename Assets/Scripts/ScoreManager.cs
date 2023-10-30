using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static float Score;
    public bool tasksDone = false;
    public static float TimeLeft = 200.0f;
    public float TimeDecrease = 0.05f;
    private void Start()
    {
        Score = 0;
    }
    private void Update()
    {
        TimeLeft = TimeLeft - TimeDecrease * Time.deltaTime;
        if (TimeLeft <= 100.0f)
        {
            TimeLeft = 100f;
        }
        GuideArrow[] arrows = FindObjectsOfType<GuideArrow>();
        if (arrows.Length == 0)
        {
            SceneManager.LoadScene("ScoreScreen");
        }
    }
}
