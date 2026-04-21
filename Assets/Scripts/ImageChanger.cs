using UnityEngine;

public class ImageChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void changeBackground(string inputBackground) {
        if (inputBackground != "") spriteRenderer.sprite = Resources.Load<Sprite>("InputBackground/" + inputBackground);
    }
    public void changeCharacter(string inputSprite) {
        spriteRenderer.sprite = Resources.Load<Sprite>("InputCharacter/" + inputSprite);
        //if ("\n" + inputSprite == "V1") print(inputSprite +" = V1");
        //else print("\n" + inputSprite + " != V1");
        // spriteRenderer.sprite = Resources.Load<Sprite>("InputCharacter/V1");
    }
}
