using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CityManager : MonoBehaviour
{
    public static CityManager instance;
    public List<Vector3Int> cities;
    public GameObject cityLimitPrefab;
    void Awake()
    {
        instance = this;
        cities = new List<Vector3Int>();
    }
    public static int GetCityNearPoint(Vector3Int position)
    {
        for (int i = 0; i < instance.cities.Count; i++)
        {
            if (instance.cities[i].x - 2 <= position.x && instance.cities[i].x + 2 >= position.x && 
                instance.cities[i].y - 2 <= position.y && instance.cities[i].y + 2 >= position.y)
            {
                return i;
            }
        }
       return -1; 
    }
    public static bool AddCity(Vector3Int position)
    {
        if (TileManager.GetBuildingAt(position) == null)
        {
            instance.cities.Add(position);
            Instantiate(instance.cityLimitPrefab, position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
            return true;
        }
        return false;
    }


}
