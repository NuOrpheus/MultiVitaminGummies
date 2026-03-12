using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CsvParser : MonoBehaviour {
    public string tmp;
    public string InputDialogue = "inputDialogue";
    public string InputSpeaker = "inputSpeaker";
    public string InputChoice1 = "inputChoice1";
    public string InputChoice2 = "inputChoice2";
    public string InputExit1 = "start1";
    public string InputExit2 = "start1";
    public Dictionary<string, Dictionary<string, string>> storage = new Dictionary<string, Dictionary<string, string>>();
    //Debug.Log(InputExits[0]);
    private void AddOuterSection(string section) {
        storage.Add(section, new Dictionary<string, string>());
    }
    private void AddInnerSection(string section, string value1, string value2) {
        storage[section].Add(value1, value2);
    }
    public void nextSection(string section) {
        InputSpeaker = storage[section]["speaker"];
        InputDialogue = storage[section]["dialogue"];
        InputChoice1 = storage[section]["choice1"];
        InputChoice2 = storage[section]["choice2"];
        InputExit1 = storage[section]["exit1"];
        InputExit2 = storage[section]["exit2"];
        
        //return(string[storage[section]["exit1"],storage[section]["exit2"]]);
    }
    void Start()
    {
        //https://discussions.unity.com/t/how-to-read-a-dataset-from-a-csv/783544/6 start copied code
        TextAsset dataset = Resources.Load<TextAsset>("dialogue");
        string[] lines = dataset.text.Split("\n");
        List<List<string>> lists = new List<List<string>>();
        for (int i = 0; i < lines.Length; i++) {
            string[] data = lines[i].Split(",");
            List<string> list = new List<string>(data);
            lists.Add(list);
        }
        /////////// end copied code
        /*AddOuterSection("start1");
        AddInnerSection("start1","speaker","???");
        AddInnerSection("start1","dialogue","first dialogue");
        AddInnerSection("start1","choice1","first choice");
        AddInnerSection("start1","choice2","second choice");
        AddInnerSection("start1","exit1","start1A");
        AddInnerSection("start1","exit2","start1B");
        foreach(var z in storage) {
            Debug.Log(z.Key);
            //Debug.Log(z.Value);
            foreach(var y in z.Value) {
                Debug.Log(y.Key +y.Value);
                //Debug.Log(y.Value);
            }
        }*/
        //Debug.Log(storage["start1"]["speaker"]);
        for (int col = 1; col < lists.Count-1; col++) {
            for (int row = 0; row < /*lists.Count*/7; row++) {
                try {
                    if (row == 0) {
                        AddOuterSection(lists[col][row]);
                        tmp = lists[col][row];
                    } else if (row == 1) AddInnerSection(tmp, "speaker", lists[col][row]);
                    else if (row == 2) AddInnerSection(tmp, "dialogue", lists[col][row]);
                    else if (row == 3) AddInnerSection(tmp, "choice1", lists[col][row]);
                    else if (row == 4) AddInnerSection(tmp, "choice2", lists[col][row]);
                    else if (row == 5) AddInnerSection(tmp, "exit1", lists[col][row]);
                    else if (row == 6) AddInnerSection(tmp, "exit2", lists[col][row]);
                } catch {}
            }
        }
    }
}