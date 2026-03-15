using UnityEngine;

[CreateAssetMenu(fileName = "FoodConfig", menuName = "Scriptable Objects/FoodConfig")]
public class FoodConfig : ScriptableObject
{
    [SerializeField] public Sprite Sprite;
    [SerializeField] public FoodType Type;
    [SerializeField] public bool NeedsPrep;
}
