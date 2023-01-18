using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoStartDialogue : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
        //Startar dialogen så fort scenen startar -William
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        dialogueTrigger.TriggerDialogue();
    }
}
