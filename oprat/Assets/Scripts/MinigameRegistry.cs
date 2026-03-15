using UnityEngine;

public class MinigameRegistry : MonoBehaviour
{
    MinigameManager minigameManager;
    [SerializeField] MinigameConfig milkConfig;
    [SerializeField] MinigameConfig fishConfig;
    [SerializeField] MinigameConfig fruitConfig;
    [SerializeField] MinigameConfig maizeConfig;

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

    public void StartFruit()
    {
        minigameManager.EnterGame(fruitConfig);
    }

    public void StartMaize()
    {
        minigameManager.EnterGame(maizeConfig);
    }
}
