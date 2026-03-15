using UnityEngine;

[CreateAssetMenu(fileName = "MinigameConfig", menuName = "Scriptable Objects/MinigameConfig")]
public class MinigameConfig : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public string GoalInstr;
    [SerializeField] public string ControlsInstr;
    [SerializeField] public int cost;
    [SerializeField] public Color backgroundColor;
    [SerializeField] public Color gameWindowColor;
    [SerializeField] public GameObject gameSourcePrefab;
    [SerializeField] public FoodConfig foodConfig;
}
