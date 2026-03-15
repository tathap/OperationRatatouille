using System;
using UnityEngine;

[Serializable]
public class FoodInstance
{
    [SerializeField] int condition;
    [SerializeField] FoodConfig config;


    public FoodInstance(int condition, FoodConfig config)
    {
        this.condition = condition;
        this.config = config;
    }

    public int GetCondition()
    {
        return condition;
    }
    public FoodConfig GetFoodConfig()
    {
        return config;
    }

}
