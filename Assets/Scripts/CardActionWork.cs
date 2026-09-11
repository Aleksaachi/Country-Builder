using UnityEngine;

[CreateAssetMenu(fileName = "CardActionWork", menuName = "Scriptable Objects/Card/Action/Work")]
public class CardActionWork : CardBase
{
    public override bool UseOnTile(Vector3Int position)
    {
        City city = CityManager.GetCityNearPoint(position);
        if (city != null){
            Building buildingOnTile = city.GetBuildingAtTile(position);
            if (buildingOnTile != null){
                WorkType workType = buildingOnTile.workType;
                city.WorkCity(workType);
                return true;
            }
        }
        return false;
    }
}
