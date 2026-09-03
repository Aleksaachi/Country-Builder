using UnityEngine;

public class CardInHand : MonoBehaviour
{
    public void OnEnter()
    {
        Hand.OnCardEnter(this);
    }
    public void OnLeave()
    {
        Hand.OnCardLeave(this);
    }
    public void OnStartDrag(){
        Hand.OnCardStartDrag(this);
    }
    public void OnEndDrag(){
        Hand.OnCardEndDrag(this);
    }
}
