using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RoundStateManager : MonoBehaviour
{
    MinigameManager minigameManager;

    [Header("DO NOT TOUCH MY VALUES!!!")]
    [SerializeField] int round;
    [SerializeField] int money;
    [SerializeField] int qualityScore = 0;
    [SerializeField] int varietyScore = 0;

    [Header("Cart")]
    [SerializeField] List<FoodInstance> cart = new List<FoodInstance>();

    bool hasProduce = false;
    bool hasGrain = false;
    bool hasProtein = false;
    bool hasDairy = false;


    [Header("UI FIELDS")]
    [SerializeField] TMP_Text weekText;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text qualityText;
    [SerializeField] TMP_Text varietyText;
    [SerializeField] GameObject dairyInCart;
    [SerializeField] GameObject grainInCart;
    [SerializeField] GameObject proteinInCart;
    [SerializeField] GameObject produceInCart;

    public void UpdateUI()
    {
        weekText.text = "week: " + (round + 1).ToString();
        moneyText.text = "money: " + money.ToString();
        if (cart.Count > 0)
        {
            qualityText.text = "avg quality: " + ((float)qualityScore / cart.Count).ToString("F2");
            varietyText.text = "avg variety: " + ((float)varietyScore / cart.Count).ToString("F2");
        }
        else
        {
            qualityText.text = "N/A";
            varietyText.text = "N/A";
        }

        dairyInCart.SetActive(hasDairy);
        grainInCart.SetActive(hasGrain);
        proteinInCart.SetActive(hasProtein);
        produceInCart.SetActive(hasProduce);
    }

    public void Awake()
    {
        minigameManager = FindFirstObjectByType<MinigameManager>();
    }

    public void Start()
    {
        // test initialize
        Initialize(4, 50);
    }

    public void Initialize(int round, int money)
    {
        this.round = round;
        this.money = money;
        UpdateUI();
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
            money -= config.cost;
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
        qualityScore += food.GetCondition();

        FoodConfig fc = food.GetFoodConfig();

        if (!hasProduce && fc.Type == FoodType.PRODUCE)
        {
            hasProduce = true;
            varietyScore++;
        }
        if (!hasGrain && fc.Type == FoodType.GRAIN)
        {
            hasGrain = true;
            varietyScore++;
        }
        if (!hasProtein && fc.Type == FoodType.PROTEIN)
        {
            hasProtein = true;
            varietyScore++;
        }
        if (!hasDairy && fc.Type == FoodType.DAIRY)
        {
            hasDairy = true;
            varietyScore++;
        }

        UpdateUI();
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
