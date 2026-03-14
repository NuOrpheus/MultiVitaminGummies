using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CsvParser : MonoBehaviour {
    public string tmp;
    public string InputDialogue;
    public string InputSpeaker;
    public string InputChoice1;
    public string InputChoice2;
    public string InputExit1;
    public string InputExit2;
    public Dictionary<string, Dictionary<string, string>> storage = new Dictionary<string, Dictionary<string, string>>();
    private void AddOuterSection(string section) {
        storage.Add(section, new Dictionary<string, string>());
    }
    private void AddInnerSection(string section, string value1, string value2) {
        storage[section].Add(value1, value2);
    }
    public void nextSection(string section) {
        try {InputSpeaker = storage[section]["speaker"];} 
        catch {InputSpeaker = "";}
        try {InputDialogue = storage[section]["dialogue"];}
        catch{InputDialogue = "";}
        try {InputChoice1 = storage[section]["choice1"];}
        catch {InputChoice1 = "";}
        try {InputChoice2 = storage[section]["choice2"];}
        catch {InputChoice1 = "";}
        try {InputExit1 = storage[section]["exit1"];}
        catch {InputExit1 = "";}
        try {InputExit2 = storage[section]["exit2"];}
        catch {InputExit2 = "";}
    }
    void Awake()
    {
        //https://discussions.unity.com/t/how-to-read-a-dataset-from-a-csv/783544/6 
        // start copied code 
        // (the following code is almost completely untouched by me)
        TextAsset dataset = Resources.Load<TextAsset>("dialogue");
        string[] lines = dataset.text.Split("\n");
        List<List<string>> lists = new List<List<string>>();
        for (int i = 0; i < lines.Length; i++) {
            string[] data = lines[i].Split(",");
            List<string> list = new List<string>(data);
            lists.Add(list);
        }
        // end copied code
        for (int col = 1; col < lists.Count-1; col++) {
            for (int row = 0; row < 7; row++) {
                try {
                    switch (row) {
                        case 0:
                            tmp = lists[col][row];
                            AddOuterSection(tmp);
                            
                            break;
                        case 1: 
                            AddInnerSection(tmp, "speaker", lists[col][row]);
                            break;
                        case 2: 
                            AddInnerSection(tmp, "dialogue", lists[col][row].Replace("//", ","));
                            break;
                        case 3: 
                            AddInnerSection(tmp, "choice1", lists[col][row]);
                            break;
                        case 4: 
                            AddInnerSection(tmp, "choice2", lists[col][row]);
                            break;
                        case 5: 
                            AddInnerSection(tmp, "exit1", lists[col][row]);
                            break;
                        case 6:
                            AddInnerSection(tmp, "exit2", lists[col][row]);
                            break;
                    }
                } catch {}
            }
        }
        nextSection("start");
    }
}