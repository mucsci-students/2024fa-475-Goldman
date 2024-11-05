using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public bool inUse;

    public GameObject currentTile;
    /*
    void Start()
    {
        
    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tile")
        {
            currentTile = other.gameObject;
            inUse = true;
        }
    }
}
