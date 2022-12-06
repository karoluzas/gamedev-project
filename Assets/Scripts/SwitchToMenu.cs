using UnityEngine;

public class SwitchToMenu : MonoBehaviour
{
    [SerializeField]
    private int mainMenuScene;

    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuScene);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            LoadMenu();
    }
}