using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timerText; 
    public float currentTime = 0f;
       

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 60;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime-=Time.deltaTime;
         timerText.text = currentTime.ToString("0.00");
    }
}
