using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] public GameObject choicesPanel;
    [SerializeField] public TMP_Text currentChoice1;
    [SerializeField] public TMP_Text currentChoice2;
    [SerializeField] public TMP_Text currentDialogue;
    [SerializeField] public TMP_Text currentSpeaker ;
    private string nextDialogue = "nextdialogue";
    private string nextSpeaker = "nextspeaker";
    private string nextChoice1 = "nextChoice1";
    private string nextChoice2 = "nextChoice2";
    private float x = 0f;
    private void Start() {
        ChoicesActivation(true);
    }
    public void Update() {
        x += Time.deltaTime;
        if (Input.GetButton("Jump")) {
            if (x > 0.2) {
                ChangeDialogue();
                ChangeSpeaker();
                ChangeChoices();
                x = 0;
            }
        }
    }
    public void ChangeDialogue() {
        currentDialogue.text = nextDialogue;
        nextDialogue = "next" + nextDialogue;   
    }
    public void ChangeSpeaker() {
        currentSpeaker.text = nextSpeaker;
        nextSpeaker = "next" + nextSpeaker;   
    }
    public void ChangeChoices() {
       currentChoice1.text = nextChoice1;
       nextChoice1 = "next" + nextChoice1;
       currentChoice2.text = nextChoice2;
       nextChoice2 = "next" + nextChoice2;

    }
    public void ChoicesActivation(bool x) {
        choicesPanel.SetActive(x);
    }   
}