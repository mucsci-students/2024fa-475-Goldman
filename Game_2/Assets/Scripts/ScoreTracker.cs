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
    public string scoreSaveText;
    public string tileSaveText;


    void Start()
    {
        //score = PlayerPrefs.GetInt("MainTile", 0);
        
        highestTile = PlayerPrefs.GetInt(tileSaveText, 4);
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
    //scoring for 2v2
    public void VersusScore()
    {

    }
    //scoring for 8x8
    public void BigScore()
    {

    }
    public void SaveScore(){
        if(PlayerPrefs.GetInt(scoreSaveText, 0) < score){
            PlayerPrefs.SetInt(scoreSaveText, score);
        }
        if(PlayerPrefs.GetInt(tileSaveText, 4) < highestTile){
            PlayerPrefs.SetInt(tileSaveText, highestTile);
        }
    }
}