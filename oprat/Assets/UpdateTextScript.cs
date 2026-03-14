using UnityEngine;
using UnityEngine.UI;

public class UpdateTextScript : MonoBehaviour
{
    public LogicScript logicScript;
    public Text curText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int numFishNeeded = 3 - logicScript.numChosen;
        int numFishLeft = 9 - logicScript.considerIndex + 1;
        curText.text = "Number of fish left to buy: " + numFishNeeded + "\nNumber of fish left: " + numFishLeft;
    }
}
