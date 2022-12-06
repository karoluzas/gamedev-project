using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMenu : MonoBehaviour
{
    [SerializeField]
    private int mainMenuScene;

    [SerializeField]
    private bool listenToEscapeKey = false;

    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Single);
    }

    public void Update()
    {
        if (listenToEscapeKey && Input.GetKeyDown(KeyCode.Escape))
            LoadMenu();
    }
}