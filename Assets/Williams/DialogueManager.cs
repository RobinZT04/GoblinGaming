using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image characterImage;
    private bool changeScene;

    public Animator dialogueAnimator;
    public Animator fadeAnimator;
    public AudioSource audioSource;

    private Queue<string> sentences;
    private Queue<AudioClip> audioClips;
    private Queue<Sprite> sprites;
    private Queue<string> names;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        sentences = new Queue<string>();
        audioClips = new Queue<AudioClip>();
        sprites = new Queue<Sprite>();
        names = new Queue<string>();
    }
    private void Update()
    {
        //Klickar man p? v?nsterklick s? visas n?sta del av dialogen -William
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space) && dialogueAnimator.GetBool("IsOpen"))
        {
            DisplayNextSentence();
        }

    }
    public void StartDialogue(Dialogue dialogue)
    {
        changeScene = dialogue.changeScene;

        //Startar dialogen med en animation -William
        dialogueAnimator.SetBool("IsOpen", true);
        fadeAnimator.SetBool("IsOpen", true);

        //T?mmer queuen innan man startar upp en ny dialog -William
        sentences.Clear();
        audioClips.Clear();
        sprites.Clear();
        names.Clear();

        //Varje mening/ljudfil/sprite/namn l?ggs in i sin queue -William
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        //Har en if-sats f?r jag orkar inte ha en ljudfil vid varje test, ta bort den h?r senare -William
        if (dialogue.audioClips.Length > 0)
        {
            foreach (AudioClip audioClip in dialogue.audioClips)
            {
                audioClips.Enqueue(audioClip);
            }
        }
        foreach (Sprite sprite in dialogue.sprites)
        {
            sprites.Enqueue(sprite);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        //Om det inte ?r n?gra mer meningar s? st?ngs dialogen ner -William
        if (sentences.Count == 0)
        {
            audioSource.Stop();
            EndDialogue();

            //?ndrar scenen till n?sta scen ifall den ska ?ndras -William
            if (changeScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            return;
        }

        //Anv?nder den nuvarande dialogen/ljudklippet/spriten/namnet i queuen och tar sedan bort den fr?n queuen -William
        string sentence = sentences.Dequeue();
        //Har en if-sats f?r jag orkar inte ha en ljudfil vid varje test, ta bort den h?r senare -William
        if (audioClips.Count > 0)
        {
            AudioClip audioClip = audioClips.Dequeue();

            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        //AudioClip audioClip = audioClips.Dequeue();
        Sprite sprite = sprites.Dequeue();
        string name = names.Dequeue();
        characterImage.sprite = sprite;
        nameText.text = name;

        /*audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();*/
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    //G?r s? att bara en bokstav skrivs varje 3 frames -William
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
        PlayerMovement.canmove = true;
        dialogueAnimator.SetBool("IsOpen", false);
        fadeAnimator.SetBool("IsOpen", false);
    }
}
