using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static float Score;
    public bool tasksDone = false;
    public Fire fire;
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
            SceneManager.LoadScene("ScoreScreen");
        }
    }
}
