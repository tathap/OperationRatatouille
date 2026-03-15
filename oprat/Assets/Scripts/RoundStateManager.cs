using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RoundStateManager : MonoBehaviour
{
    MinigameManager minigameManager;

    [Header("DO NOT TOUCH MY VALUES!!!")]
    [SerializeField] public int round;
    [SerializeField] public int money;
    [SerializeField] public int qualityScore = 0;
    [SerializeField] public int varietyScore = 0;

    [Header("Cart")]
    [SerializeField] public List<FoodInstance> cart = new List<FoodInstance>();

    [SerializeField] List<FoodInstance> supermarketHaulTemplate = new List<FoodInstance>();
    [SerializeField] List<FoodInstance> fastFoodHaulTemplate = new List<FoodInstance>();

    bool hasProduce = false;
    bool hasGrain = false;
    bool hasProtein = false;
    bool hasDairy = false;


    [Header("UI FIELDS")]
    [SerializeField] TMP_Text foodCt;
    [SerializeField] TMP_Text weekText;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text qualityText;
    [SerializeField] TMP_Text varietyText;
    [SerializeField] GameObject dairyInCart;
    [SerializeField] GameObject grainInCart;
    [SerializeField] GameObject proteinInCart;
    [SerializeField] GameObject produceInCart;

    public float GetQualityAvg()
    {
        return (float)qualityScore / cart.Count;
    }

    public void UpdateUI()
    {
        foodCt.text = "# food: " + cart.Count;
        weekText.text = "week: " + (round + 1).ToString();
        moneyText.text = "$" + money.ToString();
        if (cart.Count > 0)
        {
            qualityText.text = "avg quality: " + ((float)qualityScore / cart.Count).ToString("F2");
            varietyText.text = "variety: " + varietyScore;
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

    public void Initialize(int round, int money)
    {
        this.round = round;
        this.money = money;
        UpdateUI();
    }
    public void OnPurchaseSupermarket(VendorConfig config)
    {
        money -= config.cost;
        print(config.cost);

        foreach (FoodInstance item in supermarketHaulTemplate)
        {
            RecieveGameReward(item);
        }

    }

    public void OnPurchaseFastFood(VendorConfig config)
    {
        money -= config.cost;
        print(config.cost);

        foreach (FoodInstance item in fastFoodHaulTemplate)
        {
            RecieveGameReward(item);
        }
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
