using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    public int food;
    public int wood;
    public int steel;
    public TextMeshProUGUI textBoxFood;
    public TextMeshProUGUI textBoxWood;
    public TextMeshProUGUI textBoxSteel;
    const int RESOURCE_LIMIT = 999999;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UpdateUI();
    }
    public static void ChangeResource(Resource resource, int change)
    {
        switch (resource)
        {
            case Resource.Food:
            instance.food = Mathf.Clamp(change + instance.food, 0, RESOURCE_LIMIT);
            break;

            case Resource.Wood:
            instance.wood = Mathf.Clamp(change + instance.wood, 0, RESOURCE_LIMIT);
            break;

            case Resource.Steel:
            instance.steel = Mathf.Clamp(change + instance.steel, 0, RESOURCE_LIMIT);
            break;

            default:
            break;
        }
        UpdateUI();
    }
    public static int GetAmountOfResource(Resource resource)
    {
        if      (resource == Resource.Food)  return instance.food;
        else if (resource == Resource.Wood)  return instance.wood;
        else if (resource == Resource.Steel) return instance.steel;
        return -1;
    }
    public static void UpdateUI()
    {
        instance.textBoxFood.text = instance.food.ToString();
        instance.textBoxWood.text = instance.wood.ToString();
        instance.textBoxSteel.text = instance.steel.ToString();
    }
    public static bool ConsumeResources(List<Resource> cost, List<int> amount)
    {
        if (!CheckForResources(cost, amount)) return false;

        for (int i = 0; i < cost.Count; i++)
        {
            ChangeResource(cost[i], -amount[i]);
        }
        UpdateUI();

        return true;
    }
    public static bool CheckForResources(List<Resource> cost, List<int> amount)
    {
        for (int i = 0; i < cost.Count; i++)
        {
            if (GetAmountOfResource(cost[i]) < amount[i])
            {
                return false;
            }
        }
        return true;
    }
}

public enum Resource
{
    Food,
    Wood,
    Steel
}
