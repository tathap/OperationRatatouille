using UnityEngine;

public class MinigameRegistry : MonoBehaviour
{
    MinigameManager minigameManager;
    [SerializeField] MinigameConfig milkConfig;
    [SerializeField] MinigameConfig fishConfig;

    public void Awake()
    {
        minigameManager = FindFirstObjectByType<MinigameManager>();
    }

    public void StartMilk()
    {
        minigameManager.EnterGame(milkConfig);
    }

    public void StartFish()
    {
        minigameManager.EnterGame(fishConfig);
    }
}
