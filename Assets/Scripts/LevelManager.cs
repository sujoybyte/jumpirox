using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject gameMenu;

    private void Start()
    {
        if (gameMenu.activeSelf)
            Time.timeScale = 0f;
    }

    public void Play()
    {
        gameMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        // Settings
    }

    public void About()
    {
        // About the game
    }

    public void Exit()
    {
        Application.Quit();
    }
}

