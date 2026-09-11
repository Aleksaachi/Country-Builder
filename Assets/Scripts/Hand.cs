using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static Hand instance;
    public List<Transform> cardsInHand = new();
    public float offsetMultiplier;
    public float radius;
    public Vector3 circleCenter;
    int hoverIndex;
    int selectedIndex;
    public GameObject cardObjectPrefab;
    void Awake(){
        instance = this;
        hoverIndex = -1;
        selectedIndex = -1;
    }
    void Update()
    {
        UpdateCardPosition();
    }
    void UpdateCardPosition()
    {
        float centerIndex = Mathf.Floor(cardsInHand.Count/2);
        if (cardsInHand.Count % 2 == 0) centerIndex -= 0.5f;
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            float rotation = (i - centerIndex) * offsetMultiplier + 90;
            float x = Mathf.Cos(rotation * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(rotation * Mathf.Deg2Rad) * radius + circleCenter.y;

            if (i != selectedIndex){
                if (i == hoverIndex)
                {
                    y += 100f;
                    cardsInHand[i].rotation = Quaternion.Euler(0, 0, 0);
                    cardsInHand[i].localScale = new Vector3(1.25f, 1.25f, 1);
                }
                else
                {
                    cardsInHand[i].rotation = Quaternion.Euler(0, 0, rotation - 90);
                    cardsInHand[i].localScale = Vector3.one;
                }
                cardsInHand[i].SetSiblingIndex(i);
                cardsInHand[i].transform.localPosition = new Vector3(x, y, 0);
            }
            else
            {
                y += 100f;
                cardsInHand[i].rotation = Quaternion.Euler(0, 0, 0);
                cardsInHand[i].localScale = new Vector3(1.25f, 1.25f, 1);
                cardsInHand[i].transform.localPosition = Vector3.Lerp(new Vector3(x, y, 0), Input.mousePosition + transform.parent.position, 0.1f);
            }
        }
        if (hoverIndex != -1) cardsInHand[hoverIndex].SetAsLastSibling();
        if (selectedIndex != -1) cardsInHand[selectedIndex].SetAsLastSibling();
    }
    public static void OnCardEnter(CardInHand cardObject)
    {
        instance.hoverIndex = instance.cardsInHand.IndexOf(cardObject.transform);
    }
    public static void OnCardLeave(CardInHand cardObject)
    {
        int index = instance.cardsInHand.IndexOf(cardObject.transform);
        if (instance.hoverIndex == index)
        {
            instance.hoverIndex = -1;
        }
    }
    public static void OnCardStartDrag(CardInHand cardObject)
    {
       instance.selectedIndex = instance.cardsInHand.IndexOf(cardObject.transform); 
       Cursor.SetActive(true);
    }
    public static void OnCardEndDrag(CardInHand cardObject)
    {
       PlayCardObject(cardObject);
       Cursor.SetActive(false);
    }
    public static void RemoveCardFromHand(CardInHand cardObject)
    {
        instance.cardsInHand.Remove(cardObject.transform);
        Destroy(cardObject.gameObject);
    }
    public static bool PlayCardObject(CardInHand cardObject){
        if (cardObject == null || cardObject.thisCard == null) return false;
        bool success = PlayCard(cardObject.thisCard);
        if (success)
        {
            RemoveCardFromHand(cardObject);
            instance.selectedIndex = -1;
            instance.hoverIndex = -1;
        }
        else
        {
            int index = instance.cardsInHand.IndexOf(cardObject.transform);
            if (instance.selectedIndex == index)
            {
                instance.selectedIndex = -1;
            }
        }
        
        return success;
    }
    public static bool PlayCard(CardBase card)
    {
        if (!ResourceManager.CheckForResources(card.cardCostType, card.cardCost)) return false;

        bool used;
        if (card.needTile){
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = TileManager.GetGridPosition(worldPosition);

            used = card.UseOnTile(gridPosition);
        }
        else
        {
            used = card.Use();
        }
        
        if (used)
        {
            ResourceManager.ConsumeResources(card.cardCostType, card.cardCost);
        }
        return used;
    }
    public static void AddCardToHand(CardBase card)
    {
        CardInHand newCard = Instantiate(instance.cardObjectPrefab, instance.transform).GetComponent<CardInHand>();
        newCard.thisCard = card;

        instance.cardsInHand.Add(newCard.transform);
    }
}
