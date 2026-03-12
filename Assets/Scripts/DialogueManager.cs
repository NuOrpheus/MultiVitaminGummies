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
    private float x = 0f;
    public CsvParser csvParser;
    private void Start() {
        csvParser = GetComponent<CsvParser>();
        ChoicesActivation(false);
    }
    public void Update() {
        x += Time.deltaTime;
        if (Input.GetButton("Jump")) {
            if (x > 0.2) {
                try {
                ChangeText(csvParser.InputExit1);
                x = 0;
                } catch {}
            }
        }
    }
    public void ChangeText(string section) {
        currentDialogue.text = csvParser.InputDialogue;
        currentSpeaker.text = csvParser.InputSpeaker;  
        currentChoice1.text = csvParser.InputChoice1;
        currentChoice2.text = csvParser.InputChoice2;
        csvParser.nextSection(section);
    }
    public void ChoicesActivation(bool x) {
        choicesPanel.SetActive(x);
    }   
}