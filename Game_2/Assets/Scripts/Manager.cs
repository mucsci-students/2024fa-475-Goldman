using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool isGameOver = false;
    public PauseGame menu;

    void Start()
    {

    }

    void Update()
    {

    }
    public void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0;
        menu.GameOver();
        //change score to current score value
    }
}
