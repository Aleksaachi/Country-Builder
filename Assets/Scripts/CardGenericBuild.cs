using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New card", menuName = "Scriptable Objects/Card/Build/Generic Build")]
public class CardGenericBuild : CardBase
{
    public TileBase buildingTile;

    public override CardGenericBuild GetGenericBuild()
    {
        return this;
    }

    public override bool UseOnTile(Vector3Int position)
    {
        if (TileManager.GetBuildable(position)){
            TileManager.SetBuidlingAt(position, buildingTile);
            return true;
        }
        return false;
    }
}
