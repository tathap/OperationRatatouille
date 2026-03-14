using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class MilkGameManager : MonoBehaviour
{

    Animator anim;
    MilkGameHook gameHook;

    [SerializeField] TMP_Text timerText;
    [SerializeField] float gameTime;


    [SerializeField] Slider valueSlider;
    [SerializeField] Slider markerSlider;
    [SerializeField] GameObject fridge;

    float targetValue;
    float milkValue;
    [SerializeField] float milkIncrement;
    [SerializeField] float milkDecayPerSec;
    bool gameActive;

    public void Awake()
    {
        gameHook = FindFirstObjectByType<MilkGameHook>();
        anim = fridge.GetComponentInChildren<Animator>();
    }

    public void Start()
    {
        // calculate marker position
        float minV = valueSlider.minValue + 2f;
        float maxV = valueSlider.maxValue - 2f;

        targetValue = Random.Range(minV, maxV);
        markerSlider.SetValueWithoutNotify(targetValue);

        gameActive = true;
    }

    public void Update()
    {
        if (!gameActive)
        {
            return;
        }

        if (gameTime < 0)
        {
            EndGame();
            return;
        }

        gameTime -= Time.deltaTime;
        timerText.text = gameTime.ToString("F2");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space");
            Shake();
        }

        if (milkValue > 0)
        {
            milkValue -= milkDecayPerSec * Time.deltaTime;
        }

        // clamp milk
        milkValue = Mathf.Min(milkValue, valueSlider.maxValue);

        valueSlider.value = milkValue;
    }

    public void Shake()
    {
        milkValue += milkIncrement;
        anim.Play("milkATMShake");
    }

    public void EndGame()
    {
        gameActive = false;
        float diff = Mathf.Abs(milkValue - targetValue);
        int score = ComputeScore(diff);
        gameHook.HandleGameEnd(score);
    }

    int ComputeScore(float diff)
    {
        int score;
        if (diff < 0.25f)
        {
            score = 5;
        }
        else if (diff < 0.5f)
        {
            score = 4;
        }
        else if (diff < 1f)
        {
            score = 3;
        }
        else if (diff < 2f)
        {
            score = 2;
        }
        else
        {
            score = 1;
        }
        return score;
    }

}
