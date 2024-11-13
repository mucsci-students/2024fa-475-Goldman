using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour {

    private int highestTile = 2;
    public Text storyText;
   // public string scoreSaveText;
    public string tileSaveText;

    void Start() {
        highestTile = PlayerPrefs.GetInt(tileSaveText, 2);
        storyText.text = Story(highestTile);
    }

    public string Story(int highestTile) {
        if(highestTile == 2 || highestTile == 4) {
            return storyText.text = "2 & 4";
        } else if(highestTile == 8 || highestTile == 16) {
            return storyText.text = "8 & 16";
        } else if(highestTile == 32 || highestTile == 64) {
            return storyText.text = "32 & 64";
        } else if(highestTile == 128 || highestTile == 256){
            return storyText.text = "128 & 256";
        } else if(highestTile == 512){
            return storyText.text = "512";
        } else if(highestTile == 1024){
            return storyText.text = "1024";
        } else if(highestTile == 2048){
            return storyText.text = "2048";
        } else if(highestTile == 4096){
            return storyText.text = "4096";
        } else if(highestTile == 8192){
            return storyText.text = "8192";
        } else {
            return "";
        }
    }
}