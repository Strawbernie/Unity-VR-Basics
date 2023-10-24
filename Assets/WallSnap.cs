using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WallSnap : MonoBehaviour
{
    public XRSocketInteractor[] interactors;
    public PipeSnap[] pipes;

    public void CheckIfComplete()
    {
        for (int i = 0; i < interactors.Length; i++)
        {
            if (interactors[i].GetOldestInteractableSelected() == null) return;
        }

        print("Task completed");
    }

    public void CheckIfPipeCorrect()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            if (!pipes[i].correctPiece) return;
        }

        print("Task completed");
    }
}
