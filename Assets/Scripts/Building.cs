using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Building", menuName = "Scriptable Objects/Building")]
public class Building : ScriptableObject
{
    public TileBase buildingTile;
    public WorkType workType;
    public int production;
    public Resource productionResource;
    public void WorkBuilding()
    {
        ResourceManager.ChangeResource(productionResource, production);
    }
    
}

public enum WorkType
{
    None,
    Food,
    Wood,
    Steel,
    Recruit
}


