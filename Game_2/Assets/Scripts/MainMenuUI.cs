using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject GameModesUI;
    public GameObject OptionsMenuUI;
    public GameObject HelpText;
    public GameObject MusicManager;
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }

    void Awake()
    {
        DontDestroyOnLoad(MusicManager);
    }
    public void Start()
    {
        MainMenu.SetActive(true);
        GameModesUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
    }
    public void GameModes()
    {
        Debug.Log("Going to Game Modes");
        MainMenu.SetActive(false);
        GameModesUI.SetActive(true);
    }

    public void Options()
    {
        Debug.Log("Going to options");
        MainMenu.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
    public void Help()
    {
        Debug.Log("Displaying Help");
        HelpText.SetActive(true);
    }

    public void GameMenuBack()
    {
        GameModesUI.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void OptionsMenuBack()
    {
        OptionsMenuUI.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void HelpTextBack()
    {
        HelpText.SetActive(false);
    }
}
