using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static float Score;
    public bool tasksDone = false;
    public Fire fire;
    public static float TimeLeft = 200.0f;
    public float TimeDecrease = 0.05f;
    private void Start()
    {
        Score = 0;
    }
    private void Update()
    {
        if (fire.receivedPoints)
        {
            tasksDone= true;
        }
        if(tasksDone)
        {
            //SceneManager.LoadScene("ScoreScreen");
        }
        TimeLeft = TimeLeft - TimeDecrease * Time.deltaTime;
        if (TimeLeft <= 100.0f)
        {
            TimeLeft = 100f;
        }
    }
}
