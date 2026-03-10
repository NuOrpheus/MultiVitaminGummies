using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CsvParser : MonoBehaviour {
    public Dictionary<string, Dictionary<string, string>> storage = new Dictionary<string, Dictionary<string, string>>();
    private void addOuterSection(string section) {
        storage.Add(section, new Dictionary<string, string>());
    }
    private void addInnerSection(string section, string value1, string value2) {
        storage[section].Add(value1, value2);
    }
    void Start()
    {
        //https://discussions.unity.com/t/how-to-read-a-dataset-from-a-csv/783544/6 start added code
        TextAsset dataset = Resources.Load<TextAsset>("dialogue");
        string[] lines = dataset.text.Split("\n");
        List<List<string>> lists = new List<List<string>>();
        int columns = 0;
        for (int i = 0; i < lines.Length; i++) {
            string[] data = lines[i].Split(",");
            List<string> list = new List<string>(data);
            lists.Add(list);
            columns = Mathf.Max(columns, list.Count);
        }
        /////////// end added code
        addOuterSection("Speaker/Dialogue");
        addOuterSection("Current Dialogue");
        addOuterSection("Choices");
        addInnerSection("Speaker/Dialogue","???","this is dialogue");
        Debug.Log(storage);
        foreach(var z in storage) {
            Debug.Log(z.Key);
            Debug.Log(z.Value);
            foreach(var y in z.Value) {
                Debug.Log(y.Key);
                Debug.Log(y.Value);
            }
        }
        
        /*for (int col = 0; col < columns; col++) {
            for (int row = 0; row < lists.Count; row++) {
                try {
                    print(lists[col][row]);
                } catch {
                    print("*");
                }
            }
        }*/
    }
}
