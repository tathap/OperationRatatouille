using System;
using UnityEngine;

[Serializable]
public class FoodInstance
{
    [SerializeField] float condition;
    [SerializeField] FoodConfig config;


    public FoodInstance(float condition, FoodConfig config)
    {
        this.condition = condition;
        this.config = config;
    }

}
