using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public bool isGameOver = false;
    public PauseGame menu;
    public Text player2Text;

    public void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0;
        menu.GameOver();
        //change score to current score value
    }
    public void End2PlayerGame(bool isPlayer2){
        EndGame();
        if(isPlayer2)
        {
            menu.finalScore.text = "Player 2 Wins with score: " + player2Text.text.Substring(7);
        }
        else
        {
            menu.finalScore.text = "Player 1 Wins with score: " + menu.scoreText.text.Substring(7);
        }
    }
}
