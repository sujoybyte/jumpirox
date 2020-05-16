using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject menuUIObject = null;
    [SerializeField] private GameObject gameUIObject = null;
    [SerializeField] private GameObject buttonBox = null;
    [SerializeField] private GameObject settingsButton = null, aboutButton = null, exitButton = null;

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
        if (buttonBox.activeSelf)
        {
            buttonBox.SetActive(false);
            aboutButton.SetActive(true);
            exitButton.SetActive(true);
        }
        else if (!buttonBox.activeSelf)
        {
            buttonBox.SetActive(true);
            aboutButton.SetActive(false);
            exitButton.SetActive(false);
        }
    }

    public void About()
    {
        if (buttonBox.activeSelf)
        {
            buttonBox.SetActive(false);
            settingsButton.SetActive(true);
            exitButton.SetActive(true);
        }
        else if (!buttonBox.activeSelf)
        {
            buttonBox.SetActive(true);
            settingsButton.SetActive(false);
            exitButton.SetActive(false);
        }
    }

    public void Exit()
    {
        //Application.Quit();
        if (buttonBox.activeSelf)
        {
            buttonBox.SetActive(false);
            settingsButton.SetActive(true);
            aboutButton.SetActive(true);
        }
        else if (!buttonBox.activeSelf)
        {
            buttonBox.SetActive(true);
            settingsButton.SetActive(false);
            aboutButton.SetActive(false);
        }
    }
}

