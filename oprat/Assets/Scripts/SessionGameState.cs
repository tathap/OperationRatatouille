using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SessionGameState", menuName = "Scriptable Objects/SessionGameState")]
public class SessionGameState : ScriptableObject
{
    [Header("PLAYER STATE")]

    [SerializeField] public int round;
    [SerializeField] public int money;

    [Header("AGGREGATED PTS")]

    [SerializeField] public float qualityScore; // aggregated avg
    [SerializeField] public int totalVarietyScore;

    [Header("STATICS")]

    [SerializeField] public List<int> profits = new List<int>();
    [SerializeField] public string loseScene; // unable to balance budget or had bad luck with quality in the informal vendor markets, child remains sick
    [SerializeField] public string winScene; // able to balance budget and maintain quality quota for 7 weeks, child condition improves
    [SerializeField] public int maxRounds;
    [SerializeField] public float qualityThreshold;
    [SerializeField] public int minCartCount;
}