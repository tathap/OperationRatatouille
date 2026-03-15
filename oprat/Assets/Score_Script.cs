using UnityEngine;
using TMPro;
public class Score_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int score;
    public static Score_Script instance;
    public TMP_Text scoreText;
    void Awake() // Use Awake to set up the instance
    {
        instance = this;
    }

    void Start()
    {
        score=0;
        scoreText.text= "Score: " + score;
        
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
