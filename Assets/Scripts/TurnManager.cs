using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    List<CardWeightPair> rewardBank = new();
    List<CardBase> rewardHand = new();
    public CardBase workBaseCard;
    int maxRewards = 5;

    void Awake()
    {
        instance = this;
    }
    public void EndTurn()
    {
        AddCardWeightPair(workBaseCard, 1f);

        AddRewardsFromBuildings();
        CreateRewardHand();
    }
    void AddRewardsFromBuildings()
    {
        
    }
    void CreateRewardHand()
    {
        CardWeightPair[] rewardBankArray = rewardBank.ToArray();
        Array.Sort(rewardBankArray, delegate(CardWeightPair x, CardWeightPair y){return x.weight.CompareTo(y.weight);});
        Debug.Log(rewardBank.Count + " = " + rewardBankArray.Length);
        int counter = 0;
        float currentWeight = rewardBankArray[0].weight;
        List<CardWeightPair> sameWeightCards = new List<CardWeightPair>();

        while (rewardHand.Count != maxRewards)
        {
            if (rewardBankArray.Length > counter && rewardBankArray[counter].weight == currentWeight){
                sameWeightCards.Add(rewardBankArray[counter]);
                counter++;
            }
            else
            {
                int repeat = Mathf.Min(sameWeightCards.Count, maxRewards - rewardHand.Count);
                for(int i = 0; i < repeat; i++){
                    int randomIndex = UnityEngine.Random.Range(0, sameWeightCards.Count);
                    rewardHand.Add(sameWeightCards[randomIndex].card);
                    sameWeightCards.RemoveAt(randomIndex);
                }

                if (rewardBankArray.Length <= counter) break;
                currentWeight = rewardBankArray[counter].weight;
                sameWeightCards.Clear();
            }
        }

        for (int i = 0; i < rewardHand.Count; i++)
        {
            Hand.AddCardToHand(rewardHand[i]);
        }

        rewardHand.Clear();
        rewardBank.Clear();
    }
    public static void AddCardWeightPair(CardBase _card, float _weight)
    {
        instance.rewardBank.Add(new CardWeightPair(_card, _weight));
    }
    
}

public class CardWeightPair
{
    public float weight;
    public CardBase card;
    public CardWeightPair(CardBase _card, float _weight)
    {
        card = _card;
        weight = _weight;
    }
}
