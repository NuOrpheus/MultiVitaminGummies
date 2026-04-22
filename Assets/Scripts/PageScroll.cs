using UnityEngine;
public class PageScroll : MonoBehaviour {
    [SerializeField] RectTransform Menu3;
    [SerializeField] RectTransform Menu2;
    [SerializeField] RectTransform Menu1;
    [SerializeField] Transform Camera1;
    private Vector3 pos;

    private void Awake()
    {
        
    }

  

    public void MovePage1()
    {
        Camera1.position = new Vector3(Menu1.position.x, Menu1.position.y, -10);
    }
    public void MovePage2()
    {
        Camera1.position = new Vector3(Menu2.position.x, Menu2.position.y, -10);
    }
    public void MovePage3()
    {
        print(Camera1.position);
        Camera1.position = new Vector3(Menu3.position.x, Menu3.position.y, -10);
        print(Menu3.position);
    }

}