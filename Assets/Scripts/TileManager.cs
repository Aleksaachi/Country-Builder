using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;
    public Tilemap buidlingTilemap;
    public Tilemap decorTilemap;
    void Awake()
    {
        instance = this;
        
    }
    public static TileBase GetBuidlingAt(Vector3Int worldPosition)
    {
        return instance.buidlingTilemap.GetTile(worldPosition);
    }
    public static TileBase GetDecorAt(Vector3Int worldPosition)
    {
        return instance.decorTilemap.GetTile(worldPosition);
    }
    public static bool GetBuildable(Vector3Int worldPosition)
    {
        return GetBuidlingAt(worldPosition) == null && GetDecorAt(worldPosition) == null;
    }
    public static void SetBuidlingAt(Vector3Int worldPosition, TileBase buildingTile)
    {
        instance.buidlingTilemap.SetTile(worldPosition, buildingTile);
        
    }
    public static Vector3Int GetGridPosition(Vector2 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x);
        int y = Mathf.FloorToInt(worldPosition.y);

        return new Vector3Int(x, y, 0);
    }
}
