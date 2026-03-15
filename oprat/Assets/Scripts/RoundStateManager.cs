using System.Collections.Generic;
using UnityEngine;

public class RoundStateManager : MonoBehaviour
{
    MinigameManager minigameManager;

    int round;
    int money;
    int totalfood;
    int qualityScore = 0;
    int varietyScore = 0;
    [SerializeField] List<FoodInstance> cart = new List<FoodInstance>();

    public void Start()
    {
        // test initialize
        Initialize(1, 250, 0, 3, 3);
    }

    public void Initialize(int round, int money, int totalfood, int qualityScore, int varietyScore)
    {
        this.round = round;
        this.money = money;
        this.totalfood = totalfood;
        this.qualityScore = qualityScore;
        this.varietyScore = varietyScore;
    }

    /// <summary>
    /// Main entry point for game playing
    /// </summary>
    /// <param name="config"></param>
    public void TryPlayGame(MinigameConfig config)
    {
        if (CanAfford(config.cost))
        {
            minigameManager.EnterGame(config);
        }
    }
    /// <summary>
    /// Main exit point for game playing
    /// </summary>
    /// <param name="food"></param>
    public void RecieveGameReward(FoodInstance food)
    {
        cart.Add(food);
    }
    public bool CanAfford(int price)
    {
        return price <= money;
    }
    public void ClearCart()
    {
        cart.Clear();
    }
}
