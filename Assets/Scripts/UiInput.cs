using UnityEngine;
using TMPro;
public class UiInput : MonoBehaviour
{
    public TMP_Text currentDialogue;

    public void nextDialogue(x) {
        currentDialogue.text = x;
    }
    public void Update() {
        if Input.GetButtonDown("Jump") {
            nextDialogue("dialogue 2");
        }
    }
}
