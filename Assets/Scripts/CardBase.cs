using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New card", menuName = "Scriptable Objects/Card/Base")]
public class CardBase : ScriptableObject
{
    public string cardName;
    public Sprite icon;
    public string description;
    public CardType type;
    public List<Resource> cardCostType;
    public List<int> cardCost;
    public bool needTile;

    public enum CardType
    {
        None,
        Building,
        Action
    }

    public virtual bool UseOnTile(Vector3Int position)
    {
        Debug.Log("Base card class used.");
        return false;
    }
    public virtual bool Use()
    {
        Debug.Log("Base card class used.");
        return false;
    }
}
