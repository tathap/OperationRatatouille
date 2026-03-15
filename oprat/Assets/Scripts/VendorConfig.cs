using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VendorConfig", menuName = "Scriptable Objects/VendorConfig")]
public class VendorConfig : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public int cost;
    [SerializeField] public VendorQualityType qualityType;
    [SerializeField] public List<FoodType> types;
    [SerializeField] public MinigameConfig minigameConfig;
}
