using UnityEngine;
public class PageScroll : MonoBehaviour {
    [SerializeField] Transform Nenu3;
    [SerializeField] Transform Nenu2;
    [SerializeField] Transform Menu1;
    [SerializeField] Transform Camera1;
    private Vector3 pos;

    private void Awake()
    {
        
    }

  

    public void MovePage()
    {
        Camera1.position = Menu1.position;
    }

}