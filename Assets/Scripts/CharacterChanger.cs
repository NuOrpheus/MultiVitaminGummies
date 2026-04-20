using UnityEngine;

public class backgroundChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        //print(Resources.Load<Sprite>("InputCharacter/V1"));
        spriteRenderer = GetComponent<SpriteRenderer>();
    
    }
    public void changeSprite(string inputSprite) {
        inputSprite = inputSprite.ToString();
        spriteRenderer.sprite = Resources.Load<Sprite>("InputCharacter/" + inputSprite);
        if (inputSprite != "V1") print("no");
        //spriteRenderer.sprite = Resources.Load<Sprite>("InputCharacter/V1");
    }
}
