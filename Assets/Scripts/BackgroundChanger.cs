using UnityEngine;

public class backgroundChanger : MonoBehaviour
{
    [SerializeField] public GameObject background;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       SpriteRenderer background = background.GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
