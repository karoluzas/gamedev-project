using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMenu : MonoBehaviour
{
    [SerializeField]
    private string mainMenuScene;

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