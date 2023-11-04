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
    public Animator m_Animator;
    public GameObject PS;
    public GameObject PS1;
    public Vector3 offset;
    public void Start()
    {
        if (parentObject != null && prefabToInstantiate != null)
        {
            if (parentObject != null && prefabToInstantiate != null)
            {
                Vector3 playerPosition = parentObject.transform.position;
                Vector3 spawnPosition = playerPosition + offset;
                GameObject newChildObject = Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
                Arrow = newChildObject;
                newChildObject.transform.parent = parentObject.transform;
                Arrow.GetComponent<GuideArrow>().target = transform;
            }
        }
        PS.SetActive(false);
        PS1.SetActive(false);
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
            m_Animator.SetTrigger("SolvedPuzzle");
            StartCoroutine(ActivatePS(4));
        }
        print("Task completed");
    }
     IEnumerator ActivatePS(int Delay)
    {
        PS.SetActive(true);
        PS1.SetActive(true);
        yield return new WaitForSeconds(Delay);
        PS.SetActive(false);
        PS1.SetActive(false);
    }
 }

