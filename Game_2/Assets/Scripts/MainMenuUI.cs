using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject GameModesUI;
    public GameObject OptionsMenuUI;
    public GameObject HelpText;
    public GameObject MusicManager;
    
    public Text NormalHS;
    public Text BigHS;
    public Text VersusP1HS;
    public Text VersusP2HS;
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
    public void StartMode2(){
        Time.timeScale = 1;
        SceneManager.LoadScene("8x8");
    }
    public void StartMode3(){
        Time.timeScale = 1;
        SceneManager.LoadScene("2Player");
    }

    void Awake()
    {
        DontDestroyOnLoad(MusicManager);
    }
    public void Start()
    {
        NormalHS.text = "" + PlayerPrefs.GetInt("MainScore", 0);
        BigHS.text = "" + PlayerPrefs.GetInt("BigScore", 0);
        VersusP1HS.text = "P1: " + PlayerPrefs.GetInt("Player1Score", 0);
        VersusP2HS.text = "P2: " + PlayerPrefs.GetInt("Player2Score", 0);
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
    public void ResetScores()
    {
        PlayerPrefs.SetInt("MainScore", 0);
        PlayerPrefs.SetInt("BigScore", 0);
        PlayerPrefs.SetInt("Player1Score", 0);
        PlayerPrefs.SetInt("Player2Score", 0);
        PlayerPrefs.SetInt("MainTile", 4);
        PlayerPrefs.SetInt("BigTile", 4);
        PlayerPrefs.SetInt("Player1Tile", 4);
        PlayerPrefs.SetInt("Player2Tile", 4);

        NormalHS.text = "0";
        BigHS.text = "0";
        VersusP1HS.text = "P1: 0";
        VersusP2HS.text = "P2: 0";
    }
}
