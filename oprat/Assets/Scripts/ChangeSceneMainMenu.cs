using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] string initScene;
    [SerializeField] SessionGameState state;
    public void OnChangeScene()
    {
        state.round = 0;
        state.money = 150;
        state.qualityScore = 0;
        state.totalVarietyScore = 0;
        SceneManager.LoadScene(initScene);
    }
}
