using UnityEngine;
using DG.Tweening;
public class ButtonClickTweener : MonoBehaviour
{
    public void OnClickButton() {
        //transform.DOPunchPosition(new Vector3(0,10,0),1f,10,0);
        transform.DOScale(new Vector3(0.99f,0.99f,0),0.2f);
        transform.DOScale(new Vector3(1,1,0),0.2f).SetDelay(0.2f);
    }
}
