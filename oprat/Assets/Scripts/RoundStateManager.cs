using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    [Header("UI FIELDS")]
    [SerializeField] TMP_Text weekText;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text qualityText;
    [SerializeField] TMP_Text varietyText;

    public void UpdateUI()
    {
        weekText.text = "week: " + (round + 1).ToString();
        moneyText.text = "money: " + money.ToString();
        if (totalfood > 0)
        {
            qualityText.text = "quality: " + ((float)qualityScore / totalfood).ToString("F2");
            varietyText.text = "variety: " + ((float)qualityScore / totalfood).ToString("F2");
        }
        else
        {
            qualityText.text = "N/A";
            varietyText.text = "N/A";
        }
    }

    public void Awake()
    {
        minigameManager = FindFirstObjectByType<MinigameManager>();
    }

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
    public void TryPlayGame(VendorConfig config)
    {
        if (CanAfford(config.cost))
        {
            minigameManager.EnterGame(config.minigameConfig);
        }
        else
        {
            Debug.Log("cant afford vendor: " + config.Name);
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
