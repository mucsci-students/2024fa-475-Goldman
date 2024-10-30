using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    /*loads the selected level*/
    public void LevelLoad(int level)
    {
        SceneManager.LoadScene(level);
    }
    /*quits the game*/
    public void Quit()
    {
        Application.Quit();
    }
}
