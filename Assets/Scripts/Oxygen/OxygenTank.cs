using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{
    public float OxygenLeft = 100.0f;
    float OxygenDecrease = 0.5f;
    public Transform OxygenMeter;
    public bool isEmpty;
    bool receivedPoints = false;
    public void DepleteOxygen()
    {
        if (OxygenLeft > 0.0f)
        {
            OxygenLeft = OxygenLeft - OxygenDecrease * Difficulty.difficulty * Time.deltaTime;
            Debug.Log("Oxygen Left:" + OxygenLeft);
            Vector3 newScale = OxygenMeter.localScale;
            newScale.y = OxygenLeft/33;
            OxygenMeter.localScale = newScale;
            AddScore();
        }
    }
    private void AddScore()
    {
        if (!receivedPoints)
        {
            ScoreManager.Score = ScoreManager.Score + 10;
            receivedPoints = true;
        }
    }
}
