using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    public DialogueTrigger DT;
    // Start is called before the first frame update
    public void Start()
    {
        DT.TriggerDialogue();
    }
}
