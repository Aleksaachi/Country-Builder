using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New card", menuName = "Scriptable Objects/Pools/CardPool")]
public class CardPool : ScriptableObject
{
    public List<CardBase> cards;
}
