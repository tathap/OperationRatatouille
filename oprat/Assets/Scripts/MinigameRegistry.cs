using UnityEngine;

public class MinigameRegistry : MonoBehaviour
{
    MinigameManager minigameManager;
    [SerializeField] MinigameConfig milkConfig;

    public void Awake()
    {
        minigameManager = FindFirstObjectByType<MinigameManager>();
    }

    public void StartMilk()
    {
        minigameManager.EnterGame(milkConfig);
    }
}
