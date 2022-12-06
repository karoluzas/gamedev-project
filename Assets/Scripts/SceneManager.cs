using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private int gameStartScene;

    [SerializeField]
    private int creditsScene;

    [SerializeField]
    private int tutorialScene;

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
