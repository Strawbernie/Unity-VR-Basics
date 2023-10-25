using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogue : MonoBehaviour
{
    public DamagedWall DW;
    public DialogueTrigger AS;
    public DialogueTrigger AS1;
    bool hastriggered1 = false;
    bool hastriggered2 = false; 

    // Update is called once per frame
    void Update()
    {
        if (DW.DTtriggered &&!hastriggered1)
        {
            AS.TriggerDialogue();
            hastriggered1 = true;
        }
        if (DW.DTtriggered2 && !hastriggered2)
        {
            AS1.TriggerDialogue();
            hastriggered2 = true;
        }
    }
}
