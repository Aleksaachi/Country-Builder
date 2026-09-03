using UnityEngine;

[CreateAssetMenu(fileName = "New card", menuName = "Scriptable Objects/Card")]
public class CardBase : ScriptableObject
{
    public string cardName;
    public Sprite icon;
    public string description;
    public CardType type;

    public enum CardType
    {
        None,
        Building,
        Idea,
        Action
    }

    public virtual CardGenericBuild GetGenericBuild()
    {
        return null;
    }
    public virtual bool UseOnTile(Vector3Int position)
    {
        Debug.Log("Base card class used.");
        return false;
    }
}
