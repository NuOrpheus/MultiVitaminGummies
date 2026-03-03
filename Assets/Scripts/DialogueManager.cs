using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] public TMP_Text currentDialogue;
    private string nextDialogue = "nextdialogue";
    [SerializeField] public TMP_Text Speaker ;

    private void Start() {
        Dictionary<string, string> dialogue = new Dictionary<string, string>();
        dialogue.Add("testSpeaker", "testDialogue");
    }

    public void Update() {
        if (Input.GetButtonDown("Jump")) ChangeDialogue();
        //change to getbutton and add an interval using time.deltatime
    }

    public void ChangeDialogue() {
        currentDialogue.text = nextDialogue;
        nextDialogue = "next" + nextDialogue;   
    }

}
