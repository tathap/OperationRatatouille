using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Scorekeep : MonoBehaviour
{

    FishGameHook gameHook;
    Timer timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int score;
    public TMP_Text scoreText;
    int badFruitCount;
    void Start()
    {
        gameHook = FindFirstObjectByType<FishGameHook>();
        timer = FindFirstObjectByType<Timer>();
        score = 0;

    }
    public void UpdateScore(int points)
    {
        if (points < 0) badFruitCount++;
        score += points;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.currentTime < 0)
        {
            EndGame();
        }
    }
    int ComputeScore(int score)
    {
        if (score >= 1300 && badFruitCount == 0)
        {
            return 5;
        }
        else if (score >= 1100f)
        {
            score = 4;
        }
        else if (score >= 1000f)
        {
            score = 3;
        }
        else if (score >= 800f)
        {
            score = 2;
        }
        else
        {
            score = 1;
        }
        return score;
    }
    public void EndGame()
    {
        int score = ComputeScore(this.score);
        gameHook.HandleGameEnd(score);
    }
}
