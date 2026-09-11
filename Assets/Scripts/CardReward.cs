using UnityEngine;

public class CardReward : MonoBehaviour
{
    public CardBase cardReward;
    public void Choose()
    {
        CardRewardScreen.CloseRewardScreen(cardReward);
    }
    public void SetCard(CardBase newCard)
    {
        cardReward = newCard;
        GetComponent<CardUpdater>().UpdateVisuals(cardReward);
    }
}
