using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public bool inUse;
    /*
    void Start()
    {
        
    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tile")
        {
            inUse = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Tile")
        {
            inUse = false;
        }
    }
}
