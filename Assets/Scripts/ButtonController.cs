using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private int gameStartScene;

    [SerializeField]
    private int creditsScene;

    [SerializeField]
    private int tutorialScene;

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

    public void SwitchToCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }

    public void SwitchToTutorial()
    {
        SceneManager.LoadScene(tutorialScene);
    }
}
