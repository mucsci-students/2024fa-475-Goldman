using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileValueText : MonoBehaviour {

    public Text valueNum;

    public void updateValueText(int tileValue) {
        valueNum.text = tileValue.ToString();
    }
}