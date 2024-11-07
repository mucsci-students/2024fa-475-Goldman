using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour { 
    //public TileManager script;
    private int highestTile = 4;
    private int score = 0;
    public Text scoreText;
    public Text highText;

    public void MainScore(int tileVal){
        score += tileVal;
        if (tileVal > highestTile){
            highestTile = tileVal;
            highText.text = "Best Tile: " + highestTile;
        }
        scoreText.text = "Score: " + score;
        //Debug.Log(score);
    }
    public void SaveScore(){
        if(PlayerPrefs.GetInt("MainScore") < score){
            PlayerPrefs.SetInt("Mainscore", score);
        }
        if(PlayerPrefs.GetInt("MainTile") < score){
            PlayerPrefs.SetInt("MainTile", score);
        }
    }
}