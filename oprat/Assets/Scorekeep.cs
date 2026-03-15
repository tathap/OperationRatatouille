using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Scorekeep : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int score;
    public TMP_Text scoreText;
    void Start()
    {
        score=0;
        
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text= "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
