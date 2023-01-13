using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image characterImage;

    public Animator animator;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        //Startar dialogen med en animation -William
        animator.SetBool("IsOpen", true);

        //Ändrar texten och bilden -William
        nameText.text = dialogue.name;
        characterImage.sprite = dialogue.image;

        //Tömmer queuen innan man startar upp en ny dialog -William
        sentences.Clear();

        //Varje mening i dialogen läggs in i queuen -William
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        //Om det inte är några mer meningar så stängs dialogen ner -William
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Skriver den nuvarande meningen i sentences och tar sedan bort den från queuen -William
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    //Gör så att bara en bokstav skrivs varje 3 frames -William
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach  (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            for (int i = 0; i < 3; i++)
            {
                yield return null;
            }
        }
    }
    //Avslutar dialogen med en animation -William
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
