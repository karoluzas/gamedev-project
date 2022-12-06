using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private string gameStartScene;

    [SerializeField]
    private string creditsScene;

    [SerializeField]
    private string tutorialScene;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameStartScene);
    }

    public void SwitchToCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(creditsScene);
    }

    public void SwitchToTutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(tutorialScene);
    }
}
