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

        //�ndrar texten och bilden -William
        nameText.text = dialogue.name;
        characterImage.sprite = dialogue.image;

        //T�mmer queuen innan man startar upp en ny dialog -William
        sentences.Clear();

        //Varje mening i dialogen l�ggs in i queuen -William
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        //Om det inte �r n�gra mer meningar s� st�ngs dialogen ner -William
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Skriver den nuvarande meningen i sentences och tar sedan bort den fr�n queuen -William
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    //G�r s� att bara en bokstav skrivs varje 3 frames -William
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
