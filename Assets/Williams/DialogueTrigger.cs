using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    //Kallar p� DialogueManager f�r att starta dialogen -William
    public void TriggerDialogue()
    {
        PlayerMovement.canmove = false;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
