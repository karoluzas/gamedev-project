using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MenuDetails
{
    public GameObject menu;
    public KeyCode keyCodeToToggleMenu;
    public MenuCollisions menuActivationArea;
    public bool interruptGameplay;
}

public class MenuManager : MonoBehaviour
{
    private static KeyCode? pausedMenuKeyCode = null;
    public static bool IsGamePaused { get; private set; } = false;

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
                else if (pausedMenuKeyCode == null && menuDetails.interruptGameplay == true)
                {
                    Pause(menuDetails.menu);
                    pausedMenuKeyCode = menuDetails.keyCodeToToggleMenu;
                }
                else if (menuDetails.interruptGameplay == false)
                {
                    Toggle(menuDetails.menu);
                }
            }
            if (Input.GetKeyUp(menuDetails.keyCodeToToggleMenu)
                && (menuDetails.menuActivationArea == null || menuDetails.menuActivationArea.IsMenuAvailable))
            {
                if(menuDetails.menu.activeSelf == true && menuDetails.interruptGameplay == false)
                {
                    Toggle(menuDetails.menu);
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

    private void Toggle(GameObject menu)
    {
        menu.SetActive(!menu.activeSelf);
    }

    public static void Reset()
    {
        pausedMenuKeyCode = null;
        IsGamePaused = false;
        Time.timeScale = 1f;
    }
}
