using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    private Image spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<Image>();
    }
    public void changeBackground(string inputBackground) {
        if (inputBackground != "") spriteRenderer.sprite = Resources.Load<Sprite>("InputBackground/" + inputBackground);
    }
    public void changeCharacter(string inputSprite) {
        if (inputSprite == "") inputSprite = "null";
        spriteRenderer.sprite = Resources.Load<Sprite>("InputCharacter/" + inputSprite);
    }
}
