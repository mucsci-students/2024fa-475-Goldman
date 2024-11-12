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

    void Start()
    {
        //score = PlayerPrefs.GetInt("MainTile", 0);
        
        highestTile = PlayerPrefs.GetInt("MainTile", 4);
        highText.text = "Best Tile: " + highestTile;
    }
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
        if(PlayerPrefs.GetInt("MainScore", 0) < score){
            PlayerPrefs.SetInt("Mainscore", score);
        }
        if(PlayerPrefs.GetInt("MainTile", 4) < highestTile){
            PlayerPrefs.SetInt("MainTile", highestTile);
        }
    }
}