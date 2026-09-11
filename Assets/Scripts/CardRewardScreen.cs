using UnityEngine;
using System.Collections.Generic;

public class CardRewardScreen : MonoBehaviour
{
    public static CardRewardScreen instance;
    public GameObject rewardScreenHolder;
    public List<CardReward> listOfCards;

    void Awake()
    {
        instance = this;
    }
    public static void OpenRewardScreen(CardPool pool)
    {
        List<int> selectedIndexes = new();
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, pool.cards.Count);
            if (!selectedIndexes.Contains(index)){
                CardBase reward = pool.cards[index];
                selectedIndexes.Add(index);
                instance.listOfCards[i].SetCard(reward);
            }
            else
            {
                i--;
            }
        }
        instance.rewardScreenHolder.SetActive(true);
    }

    public static void CloseRewardScreen(CardBase selectedCard)
    {
        instance.rewardScreenHolder.SetActive(false);
        Hand.AddCardToHand(selectedCard);
    }
    public static void SkipRewardScreen()
    {
        instance.rewardScreenHolder.SetActive(false);
    }


}
