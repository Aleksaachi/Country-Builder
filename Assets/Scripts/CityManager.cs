using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CityManager : MonoBehaviour
{
    public static CityManager instance;
    public List<City> cities;
    public GameObject cityLimitPrefab;
    void Awake()
    {
        instance = this;
        cities = new List<City>();
    }
    public static City GetCityNearPoint(Vector3Int position)
    {
        for (int i = 0; i < instance.cities.Count; i++)
        {
            Vector3Int pos = instance.cities[i].position;
            if (pos.x - 2 <= position.x && pos.x + 2 >= position.x && 
                pos.y - 2 <= position.y && pos.y + 2 >= position.y)
            {
                return GetCityAtIndex(i);
            }
        }
       return null; 
    }
    public static bool AddCity(Vector3Int cityPosition)
    {
        if (TileManager.GetBuildingAt(cityPosition) == null)
        {
            City newCity = new City
            {
                position = cityPosition
            };
            instance.cities.Add(newCity);
            Instantiate(instance.cityLimitPrefab, cityPosition + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
            return true;
        }
        return false;
    }
    public static City GetCityAtIndex(int index)
    {
        return instance.cities[index];
    }
}
public class City
{
    public Vector3Int position;
    public Dictionary<Vector3Int,Building> buildings = new ();
    
    public void WorkCity(WorkType workType)
    {
        if (workType == WorkType.None) return;
        foreach (Building building in buildings.Values)
        {
            if (building.workType == workType)
            {
                building.WorkBuilding();
            }
        }
    }
    public Building GetBuildingAtTile(Vector3Int position)
    {
        if (buildings.ContainsKey(position)) return buildings[position];
        return null;
    }
    public bool AddBuilding(Building building, Vector3Int position)
    {
        if (TileManager.GetBuildable(position)){
            buildings.Add(position, building);
            TileManager.SetBuidlingAt(position, building.buildingTile);
            return true;
        }
        return false;
    }
}
