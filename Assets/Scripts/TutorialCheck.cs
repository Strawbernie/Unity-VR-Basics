using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCheck : MonoBehaviour
{
    public OxygenManager oxygenManager;
    public DamagedWall DW;
    public Fire fire;
    public HealthController healthController;

    private void Start()
    {
        healthController.inTutorial = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (DW.repaired && !oxygenManager.NoOxygen && !fire.isLit)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
