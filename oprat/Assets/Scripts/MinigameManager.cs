using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    bool gameActive;
    GameObject currentGameBase;

    [Header("UI Fields")]

    [SerializeField] GameObject mainWindow;
    [SerializeField] TMP_Text goalText;
    [SerializeField] TMP_Text controlsText;
    [SerializeField] Image backgroundPanel;
    [SerializeField] Image gameWindowPanel;

    public void EnterGame(MinigameConfig config)
    {
        mainWindow.SetActive(true);
        InitializeGameUI(config);
        StartGameLogic(config);
        gameActive = true;
    }

    public void ExitGame()
    {
        if (!gameActive) return;

        mainWindow.SetActive(false);
        StopGameLogic();
        ClearGameUI();
    }

    public void ClearGameUI()
    {
        goalText.text = "";
        controlsText.text = "";
        backgroundPanel.color = Color.black;
        backgroundPanel.color = Color.white;
    }

    public void InitializeGameUI(MinigameConfig config)
    {
        goalText.text = config.GoalInstr;
        controlsText.text = config.ControlsInstr;
        backgroundPanel.color = config.backgroundColor;
        gameWindowPanel.color = config.gameWindowColor;
    }

    public void StartGameLogic(MinigameConfig config)
    {
        currentGameBase = null;
    }
    public void StopGameLogic()
    {
        currentGameBase = null;
    }
}
