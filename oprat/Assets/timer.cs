using UnityEngine;

public class timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMPro.TextMeshProUGUI timerText;
    public float currentTime = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 60;
        timerText.text = currentTime.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.text = currentTime.ToString("0.00");
        /*
        if (currentTime==0){}
send back to main menu
        */
    }
}