using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CardActionWork", menuName = "Scriptable Objects/Card/Action/Gain Resources")]
public class CardActionGainResources : CardBase
{
    public List<Resource> resources;
    public List<int> amount;
    public override bool Use()
    {
        for (int i = 0; i < resources.Count; i++)
        {
            ResourceManager.ChangeResource(resources[i], amount[i]);
        }
        return true;
    }
}
