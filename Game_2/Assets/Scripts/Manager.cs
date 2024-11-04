using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //public bool gameOver = false;
    public GameObject GameOverUI;

    void Start()
    {

    }

    void Update()
    {

    }
    public void EndGame()
    {
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
        //change score to current score value
    }
}
