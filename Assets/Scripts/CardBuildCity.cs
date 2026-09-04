using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New card", menuName = "Scriptable Objects/Card/Build/City")]
public class CardBuildCity : CardBase
{
    public TileBase buildingTile;
    public override bool UseOnTile(Vector3Int position)
    {
        if (CityManager.AddCity(position)){
            TileManager.SetBuidlingAt(position, buildingTile);
            return true;
        }
        return false;
    }
}
