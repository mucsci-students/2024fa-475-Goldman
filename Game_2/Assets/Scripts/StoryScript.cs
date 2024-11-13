using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour {
    public string scoreSaveText;
    private int highestTile;
    public Text storyText;

    void Start() {
        highestTile = PlayerPrefs.GetInt(scoreSaveText, 2);
        Story(highestTile);
    }

    public void Story(int highestTile) {
        if(highestTile == 2 || highestTile == 4) {
            storyText.text = "2 & 4";
        } else if(highestTile == 8 || highestTile == 16) {
            storyText.text = "8 & 16";
        } else if(highestTile == 32 || highestTile == 64) {
            storyText.text = "32 & 64";
        } else if(highestTile == 128 || highestTile == 256){
            storyText.text = "128 & 256";
        } else if(highestTile == 512){
            storyText.text = "512";
        } else if(highestTile == 1024){
            storyText.text = "1024";
        } else if(highestTile == 2048){
            storyText.text = "2048";
        } else if(highestTile == 4096){
            storyText.text = "4096";
        } else if(highestTile == 8192){
            storyText.text = "8192";
        }
    }
}