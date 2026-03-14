using UnityEngine;

public interface IMinigame
{

    public void Initialize(MinigameManager manager);
    public void HandleGameEnd(int finalScore);
}