using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class LogicScript : MonoBehaviour
{
    public List<GameObject> allFish;
    List<int> order;
    List<int> finalOrder;
    bool playerClickContinue = false;
    bool playerClickEnd = false;
    public int considerIndex = 1;
    int bestIndex = 0;
    public GameObject curObject;
    public int numChosen = 0;
    List<int> chosenFish;

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
        curObject = Instantiate(allFish[bestIndex], new Vector3(-4f, 2, 0), Quaternion.identity);
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
                Debug.Log("Player has chosen all possible items!");
            }
            else
            {
                playerClickContinue = true;
            }
        }
        if (playerClickContinue) {
            if (considerIndex + (3 - numChosen) - 1 == 8)
            {
                Debug.Log(numChosen + " " + considerIndex);
                Debug.Log(bestIndex);
                Debug.Log("Player has to choose all of the remaining fish");
            }

            playerClickContinue = false;

            Destroy(curObject);
            if (considerIndex == 8)
            {
                bestIndex = 8;
              
                curObject = Instantiate(allFish[finalOrder[bestIndex]], new Vector3(-4f, 2, 0), Quaternion.identity);
                curObject.transform.localScale = new Vector3(2f, 2f, 2f);
                //game over
                Debug.Log("It's over");
            }
            else
            {
                bestIndex = considerIndex;
                considerIndex++;
                curObject = Instantiate(allFish[finalOrder[bestIndex]], new Vector3(-4f, 2, 0), Quaternion.identity);
                curObject.transform.localScale = new Vector3(2f, 2f, 2f);
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
}
