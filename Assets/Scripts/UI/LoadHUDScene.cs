using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHUDScene : MonoBehaviour
{
    public void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(7, LoadSceneMode.Additive); // load HUD scene
    }

    public void Update()
    {
        if(!UnityEngine.SceneManagement.SceneManager.GetSceneByName("HUDScene").isLoaded)
            UnityEngine.SceneManagement.SceneManager.LoadScene(7, LoadSceneMode.Additive); // load HUD scene
    }
}
