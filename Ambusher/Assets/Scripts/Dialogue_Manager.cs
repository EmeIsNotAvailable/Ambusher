using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    public Dialogue dialogue;
    Queue<string> sentences;
    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;
    string activeSentence;
    public float typingSpeed;
    AudioSource myAudio;
    public AudioClip speakSound;
    public bool ontrigger;
    public bool DialogueStart;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
    }

    void StartDialogue()
    {
        sentences.Clear();
        foreach(string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
                
    }
    void DisplayNextSentence()
        {
            if(sentences.Count <= 0)
            {
                displayText.text = activeSentence;
                return;
            }
            activeSentence = sentences.Dequeue();
            displayText.text = activeSentence;
            StopAllCoroutines();
            StartCoroutine(TypeTheSentence(activeSentence));
        }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text="";
        foreach(char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);
            ontrigger=true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            ontrigger=false;
            dialoguePanel.SetActive(false);
        }
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&ontrigger)
        {
            if(DialogueStart==false)
            {
                StartDialogue();
                DialogueStart=true;
            }
            else{
                 DisplayNextSentence();
            }
        }
        
    }
}
