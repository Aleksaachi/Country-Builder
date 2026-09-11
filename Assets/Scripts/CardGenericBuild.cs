using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New card", menuName = "Scriptable Objects/Card/Build/Generic Build")]
public class CardGenericBuild : CardBase
{
    public bool requiresCity;
    public Building building;
    public override bool UseOnTile(Vector3Int position)
    {
        City cityNearPosition = CityManager.GetCityNearPoint(position);
        if (requiresCity && cityNearPosition != null){
            return cityNearPosition.AddBuilding(building, position);
        }
        else if (!requiresCity && TileManager.GetBuildable(position))
        {
            TileManager.SetBuidlingAt(position, building.buildingTile);
            return true;
        }
        return false;
    }
}
