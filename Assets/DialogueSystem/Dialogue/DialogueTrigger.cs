using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private float DisappearTime = 3f;
    public AudioSource AS;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        StartCoroutine(EndSentence());
        AS.Play();
    }
    IEnumerator EndSentence()
    {
        yield return new WaitForSeconds(DisappearTime);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
