using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WallSnap : MonoBehaviour
{
    public XRSocketInteractor[] interactors;
    bool GunComplete = false;
    public PipeSnap[] pipes;
    bool PipeComplete = false;

    public void CheckIfComplete()
    {
        for (int i = 0; i < interactors.Length; i++)
        {
            if (interactors[i].GetOldestInteractableSelected() == null) return;
        }
        if (!GunComplete)
        {
            GunComplete = true;
            ScoreManager.Score = ScoreManager.Score + 80;
        }
        print("Task completed");
    }

    public void CheckIfPipeCorrect()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            if (!pipes[i].correctPiece) return;
        }
        if (!PipeComplete)
        {
            PipeComplete= true;
            ScoreManager.Score = ScoreManager.Score + 80;
        }
        print("Task completed");
    }
}
