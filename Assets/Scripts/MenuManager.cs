using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MenuDetails
{
    public GameObject menu;
    public KeyCode keyCodeToToggleMenu;
    public MenuCollisions menuActivationArea;
}

public class MenuManager : MonoBehaviour
{
    private static KeyCode? pausedMenuKeyCode = null;
    public static bool IsGamePaused = false;

    public List<MenuDetails> menus;

    private void Update()
    {
        foreach (var menuDetails in menus)
        {
            if (Input.GetKeyDown(menuDetails.keyCodeToToggleMenu) 
                && (menuDetails.menuActivationArea == null || menuDetails.menuActivationArea.IsMenuAvailable))
            {
                if (IsGamePaused && pausedMenuKeyCode == menuDetails.keyCodeToToggleMenu)
                {
                    Resume(menuDetails.menu);
                    pausedMenuKeyCode = null;
                }
                else if (pausedMenuKeyCode == null)
                {
                    Pause(menuDetails.menu);
                    pausedMenuKeyCode = menuDetails.keyCodeToToggleMenu;
                }
            }
        }
    }

    private void Resume(GameObject menu)
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    private void Pause(GameObject menu)
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void Reset()
    {
        pausedMenuKeyCode = null;
        IsGamePaused = false;
        Time.timeScale = 1f;
    }
}
