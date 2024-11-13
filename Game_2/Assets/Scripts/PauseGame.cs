using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public GameObject PauseMenuUI;
    public GameObject GameOverUI;
    public Text finalScore;
    public Text scoreText;
    public Manager script;
    // public GameObject[] player;
    public void GameOver()
    {
        GameOverUI.SetActive(true);
        finalScore.text = "SCORE: " + scoreText.text.Substring(7);
    }
    public void Pause()
    {
        // if not paused
        if (Time.timeScale == 1)
        {
            // pause and activate pause menu
            Time.timeScale = 0;
            PauseMenuUI.SetActive(true);
        }
        else if (!script.isGameOver)// if game ended don't unpause
        {
            // if paused, resume game and remove pause menu
            Time.timeScale = 1;
            PauseMenuUI.SetActive(false);
        }
    }

    public void Restart(int level)
    {
        // Reset player elements if necessary and set time and UI properly
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
        GameOverUI.SetActive(false);
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}