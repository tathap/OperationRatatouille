using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class FishGameLogicScript : MonoBehaviour
{
    FishGameHook gameHook;

    public List<GameObject> allFish;
    [SerializeField] List<int> order;
    [SerializeField] List<int> finalOrder;
    bool playerClickContinue = false;
    bool playerClickEnd = false;
    [SerializeField] public int considerIndex = 1;
    [SerializeField] int bestIndex = 0;
    public GameObject curObject;
    public int numChosen = 0;
    [SerializeField] List<int> chosenFish;

    [SerializeField] GameObject continueButton;


    void Awake()
    {
        gameHook = FindFirstObjectByType<FishGameHook>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        order = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            if (i == 0)
            {
                order.Add(Random.Range(0, 5));
            }
            else
            {
                order.Add(0);
                while (true)
                {
                    order[i] = Random.Range(0, 5);
                    bool found = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (order[j] == order[i])
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        finalOrder = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                finalOrder.Add(order[j]);
            }
        }
        curObject = Instantiate(allFish[bestIndex], new Vector3(-3f, 1, 0), Quaternion.identity);
        curObject.transform.localScale = new Vector3(2f, 2f, 2f);
        chosenFish = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerClickEnd)
        {
            playerClickEnd = false;
            numChosen++;
            chosenFish.Add(finalOrder[bestIndex]);
            if (numChosen == 3)
            {
                considerIndex++;
                Debug.Log("Player has chosen all possible items!");
                EndGame();
            }
            else
            {
                playerClickContinue = true;
            }
        }
        if (playerClickContinue)
        {
            playerClickContinue = false;

            Destroy(curObject);
            if (considerIndex == 8)
            {
                bestIndex = 8;

                curObject = Instantiate(allFish[finalOrder[bestIndex]], new Vector3(-3f, 1, 0), Quaternion.identity);
                curObject.transform.localScale = new Vector3(2f, 2f, 2f);
                //game over
                Debug.Log("It's over");
            }
            else
            {
                bestIndex = considerIndex;
                considerIndex++;
                curObject = Instantiate(allFish[finalOrder[bestIndex]], new Vector3(-3f, 1, 0), Quaternion.identity);
                curObject.transform.localScale = new Vector3(2f, 2f, 2f);
            }

            if (considerIndex + (3 - numChosen) >= 9)
            {
                Debug.Log(numChosen + " " + considerIndex);
                Debug.Log(bestIndex);
                Debug.Log("Player has to choose all of the remaining fish");
                continueButton.SetActive(false);
            }
        }
    }

    public void ContinueClick()
    {
        playerClickContinue = true;
    }

    public void EndClick()
    {
        playerClickEnd = true;
    }

    public int CalculateScore()
    {
        float sum = 0;
        foreach (int fish in chosenFish)
        {
            sum += fish;
        }
        int score = Mathf.RoundToInt(sum / chosenFish.Count);
        return score;
    }
    public void EndGame()
    {
        int score = CalculateScore();
        gameHook.HandleGameEnd(score);
    }
}
