﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    Controls Controls { 
        get { return ControlsManager.instance; }
    }

    public void TriggerDialogue()
    {
        if (FindObjectOfType<DialogueManager>().dialogueEnded == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Controls.Player.Disable();
            Controls.Dialogue.Enable();
        }


    }
}
