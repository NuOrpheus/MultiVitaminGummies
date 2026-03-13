using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class DialogueManager : MonoBehaviour {
    public static DialogueManager Instance;
    [SerializeField] public GameObject choicesPanel;
    [SerializeField] public TMP_Text currentChoice1;
    [SerializeField] public TMP_Text currentChoice2;
    [SerializeField] public TMP_Text currentDialogue;
    [SerializeField] public TMP_Text currentSpeaker;
    private float x = 0f;
    public CsvParser csvParser;
    private void Start() {
        csvParser = GetComponent<CsvParser>();
        choicesPanel.SetActive(false);
        ChangeText("start");
    }
    public void OnClickChoice1() {
        ChangeText(csvParser.InputExit1);
    }
    public void OnClickChoice2() {
        ChangeText(csvParser.InputExit2);
    }
    private void Update() {
        x += Time.deltaTime;
        if (Input.GetButton("Jump") && (x > 0.2)) {
            if (!choicesPanel.activeSelf) ChangeText(csvParser.InputExit1);   
            x = 0;
        }
    }
    public void ChangeText(string section) {
        csvParser.nextSection(section);
        if (string.IsNullOrEmpty(csvParser.InputChoice2)) choicesPanel.SetActive(false);
        else choicesPanel.SetActive(true);
        currentSpeaker.text = csvParser.InputSpeaker;  
        currentDialogue.text = csvParser.InputDialogue;
        currentChoice1.text = csvParser.InputChoice1;
        currentChoice2.text = csvParser.InputChoice2;
    }
}