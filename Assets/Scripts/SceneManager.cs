using UnityEngine;
using UnityEngine.SceneManagement;

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
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameStartScene, LoadSceneMode.Single);
    }

    public void SwitchToCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(creditsScene, LoadSceneMode.Single);
    }

    public void SwitchToTutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(tutorialScene, LoadSceneMode.Single);
    }
}
