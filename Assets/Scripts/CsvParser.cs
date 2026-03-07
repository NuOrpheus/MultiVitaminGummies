using UnityEngine;
using System.Collections.Generic;

public class dialogueDict {
        private Dictionary<string, Dictionary<string, string>> storage;
        public storage() {
            storage = new Dictionary<string, Dictionary<string, string>>();
    }
}
public class CsvParser : MonoBehaviour
{
    void Start()
    {
        //https://discussions.unity.com/t/how-to-read-a-dataset-from-a-csv/783544/6 changed variable types and did other fixes
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
        for (int col = 0; col < columns; col++) {
            for (int row = 0; row < lists.Count; row++) {
                try {
                    print(lists[col][row]);
                } catch {
                    print("*");
                }
            }
        }
    }
}
