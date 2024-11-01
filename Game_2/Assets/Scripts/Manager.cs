using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //public bool gameOver = false;
    public PauseGame script;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void EndGame(){
        //change
        script.Pause();
    }

}
