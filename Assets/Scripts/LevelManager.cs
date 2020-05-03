using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject menuUIObject = null;
    [SerializeField] private GameObject gameUIObject = null;

    private void Start()
    {
        if (menuUIObject.activeSelf) Time.timeScale = 0f;
    }

    public void Play()
    {
        menuUIObject.SetActive(false);
        gameUIObject.SetActive(true);
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

