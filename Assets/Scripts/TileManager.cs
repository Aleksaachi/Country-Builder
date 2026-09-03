using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;
    public Tilemap buidlingTilemap;
    public TileBase buildingTile;
    void Awake()
    {
        instance = this;
        
    }
    public static bool GetBuidlingAtWorldPosition(Vector2 worldPosition)
    {
        Vector3Int gridPosition = GetGridPosition(worldPosition);

        return instance.buidlingTilemap.GetTile(gridPosition) != null;
    }
    public static void SetBuidlingAtWorldPosition(Vector2 worldPosition)
    {
        Vector3Int gridPosition = GetGridPosition(worldPosition);

        instance.buidlingTilemap.SetTile(gridPosition, instance.buildingTile);
        
    }
    public static Vector3Int GetGridPosition(Vector2 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x);
        int y = Mathf.FloorToInt(worldPosition.y);

        return new Vector3Int(x, y, 0);
    }
}
