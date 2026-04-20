using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class DialogueManager : MonoBehaviour {
    public static DialogueManager Instance;
    [SerializeField] private GameObject choicesPanel;
    [SerializeField] private GameObject choiceObject1;
    [SerializeField] private GameObject choiceObject2;
    [SerializeField] private TMP_Text currentChoice1;
    [SerializeField] private TMP_Text currentChoice2;
    [SerializeField] private TMP_Text currentDialogue;
    [SerializeField] private TMP_Text currentSpeaker;
    [SerializeField] private backgroundChanger character;
    private float x = 0f;
    private Sprite choiceImage1;
    private bool wait = false;
    private CsvParser csvParser;
    [SerializeField] private AudioManager audioManager;
    private void Start() {
        csvParser = GetComponent<CsvParser>();
        choicesPanel.SetActive(false);
        ChangeText("start", 0);
    }
    public void OnClickChoice1() {
        audioManager.PlayButtonSfx();
        ChangeText(csvParser.InputExit1, 1);
    }
    public void OnClickChoice2() {
        audioManager.PlayButtonSfx();
        ChangeText(csvParser.InputExit2, 2);
    }
    public void OnClickNoChoice() {
        audioManager.PlayButtonSfx();
        if (!choicesPanel.activeSelf) ChangeText(csvParser.InputExit1, 0);
    }
    public void OnClickRestart() {
        audioManager.PlayButtonSfx();
        choicesPanel.SetActive(false);
        ChangeText("start", 0);
    }
    private void Update() {
        x += Time.deltaTime;
        if (Input.GetButton("Jump") && (x > 0.15)) {
            if (!choicesPanel.activeSelf && !wait) OnClickChoice1();
            x = 0;
        }
    }
    public void ChangeText(string section, int choice) {
        csvParser.nextSection(section);
        //
        character.changeSprite(csvParser.Image);
        print(csvParser.Image);
        //
        if (!string.IsNullOrEmpty(csvParser.Audio)) {
            audioManager.PlayVoiceAudio(csvParser.Audio);
        }
        if (string.IsNullOrEmpty(csvParser.InputChoice2)) {
            switch (choice) {
                case 1:
                    wait = true;
                    choiceObject2.transform.localScale = new Vector3(0,1,1);
                    Invoke(nameof(choicesOff), 0.3f);
                    break;
                case 2:
                    wait = true;
                    choiceObject1.transform.localScale = new Vector3(0,1,1);
                    Invoke(nameof(choicesOff), 0.3f);
                    break;
            }
        }
        else choicesPanel.SetActive(true);
        currentSpeaker.text = csvParser.InputSpeaker;  
        currentDialogue.text = csvParser.InputDialogue;
        if (!wait) {
            choiceObject1.transform.localScale = new Vector3(1,1,1);
            choiceObject2.transform.localScale = new Vector3(1,1,1);
            currentChoice1.text = csvParser.InputChoice1;
            currentChoice2.text = csvParser.InputChoice2;
        }
    }
    private void choicesOff() {
        choicesPanel.SetActive(false);
        currentChoice1.text = csvParser.InputChoice1;
        currentChoice2.text = csvParser.InputChoice2;
        wait = false;
    }
}
