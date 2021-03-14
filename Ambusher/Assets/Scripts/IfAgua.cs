using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IfAgua : MonoBehaviour
{
    public Dialogue dialogue;
    Queue<string> sentences;
    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;
    string activeSentence;
    public float typingSpeed;
    AudioSource myAudio;
    public AudioClip sonidoagua;
    public AudioClip speakSound;
    public bool ontrigger;
    public bool DialogueStart;
    public GameObject interaccion;
    public bool agua = false;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
    }

    void StartDialogue()
    {
        sentences.Clear();
        foreach (string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }
    void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            dialoguePanel.SetActive(false);
            DialogueStart = false;
            return;
        }
        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;
        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            ontrigger = true;
            interaccion.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ontrigger = false;
            dialoguePanel.SetActive(false);
            interaccion.SetActive(false);
            DialogueStart = false;

        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ontrigger)
        {
            if (agua)
            {
                dialoguePanel.SetActive(true);
                if (DialogueStart == false)
                {
                    StartDialogue();
                    DialogueStart = true;
                }
                else
                {
                    DisplayNextSentence();
                }
            }
            else
            {
                myAudio.PlayOneShot(sonidoagua);
                agua = true;
            }
        }

    }
}
