using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject SettingsScreen;
    public GameObject CreditsScreen;

    public void StartGame()
    {  
        SceneManager.LoadScene("Game");
        LoadingScreen.SetActive(true);
	}

    public void OpenSettings()
    {
        SettingsScreen.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsScreen.SetActive(false);
    }

    public void OpenCredits()
    {
        CreditsScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        CreditsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}