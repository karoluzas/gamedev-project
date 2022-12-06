using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMenu : MonoBehaviour
{
    [SerializeField]
    private int mainMenuScene;

    public void LoadMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            LoadMenu();
    }
}