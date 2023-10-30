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
    public GameObject parentObject;
    GameObject Arrow;
    public GameObject prefabToInstantiate;

    public void Start()
    {
        if (parentObject != null && prefabToInstantiate != null)
        {
            GameObject newChildObject = Instantiate(prefabToInstantiate);
            Arrow = newChildObject;
            newChildObject.transform.parent = parentObject.transform;
            Arrow.GetComponent<GuideArrow>().target = transform;
        }
    }
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
            Destroy(Arrow);
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
            Destroy(Arrow);
        }
        print("Task completed");
    }
}
