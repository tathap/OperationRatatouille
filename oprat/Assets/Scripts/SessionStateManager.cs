using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionStateManager : MonoBehaviour
{
    RoundStateManager rsm;
    [SerializeField] SessionGameState sessionState;

    public void Awake()
    {
        rsm = FindFirstObjectByType<RoundStateManager>();
    }

    public void Start()
    {
        OnRoundStart();
    }

    public void OnRoundStart()
    {
        rsm.Initialize(sessionState.round, sessionState.money);
    }
    public void OnRoundEnd()
    {
        int cartCount = rsm.cart.Count;
        if (cartCount < sessionState.minCartCount)
        {
            SceneManager.LoadScene(sessionState.loseScene);
            return;
        }

        float quality = rsm.GetQualityAvg();
        if (quality < sessionState.qualityThreshold)
        {
            SceneManager.LoadScene(sessionState.loseScene);
            return;
        }

        int variety = rsm.varietyScore;

        sessionState.qualityScore += quality;
        sessionState.totalVarietyScore += variety;

        sessionState.round++;
        if (sessionState.round >= sessionState.maxRounds)
        {
            SceneManager.LoadScene(sessionState.winScene);
            return;
        }

        sessionState.money = rsm.money + sessionState.profits[sessionState.round];
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
