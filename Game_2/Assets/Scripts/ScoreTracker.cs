using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreTracker : MonoBehaviour { 
    //public TileManager script;
    int highestTile = 2;
    int score = 0;

void Start()
{
    
}

void Update()
{

}

public void MainScore(int tileVal){
    score +=tileVal;
    if (tileVal > highestTile){
        highestTile = 2;
    }
}



}