using UnityEngine;

public class MilkGameHook : MonoBehaviour, IMinigame
{
    MinigameManager manager;
    public void Initialize(MinigameManager manager)
    {
        this.manager = manager;
    }
    public void HandleGameEnd(int finalScore)
    {
        manager.HandleGameEnd(finalScore);
    }
}
