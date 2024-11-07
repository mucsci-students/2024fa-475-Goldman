using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private float timer;
    private int speed = 20;
    private int maxPow = 2;
    private float waitTime = 0.4f;
    private int moveCounter

    public int numTiles;
    public bool validMoveTaken = true;

    public Manager script;
    public ScoreTracker track;
    public GameObject tilePrefab;

    void Start()
    {
        moveCounter = -1;
        timer = 0;
        StartCoroutine(SpawnTile());
        StartCoroutine(SpawnTile());
    }
    void Update()
    {
        if(Time.deltaTime == 0){
            return;
        }
        timer += Time.deltaTime;
        if(timer > waitTime)
        {
            if(Move())
            {
                timer = 0;
                StartCoroutine(SpawnTile());
            }
        }
        
    }
    public void addScore(int value)
    {
        track.MainScore(value);
    }
    //returns false if no move taken, if one is taken, moves all tiles
    bool Move()
    {
        float xVel = 0f;
        float yVel = 0f;
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            yVel = speed;
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xVel = -speed;
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            yVel = -speed;
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            xVel = speed;
        }
        else
        {
            return false;
        }
        //allows merging
        TileScript[] scripts = GetComponentsInChildren<TileScript>();
        foreach(TileScript TS in scripts)
        {
            TS.notYetMerged = true;
        }
        //gets all tiles under object
        Rigidbody2D[] children = GetComponentsInChildren<Rigidbody2D>();
        foreach(Rigidbody2D body in children)
        {
            body.velocity = new Vector2(xVel, yVel);
        }
        return true;
    }
    //spawns in tile at a random unused point
    IEnumerator SpawnTile()
    {
        yield return new WaitForSeconds(waitTime - 0.1f);
        if(!validMoveTaken && moveCounter > 0)
        {
            yield break;
        }
        moveCounter++;
        PointScript[] points = GetComponentsInChildren<PointScript>();
        int index = Random.Range(0,16);
        //once counter hits 40 assume that board is full
        int tempcounter = 0;
        while (points[index].inUse && tempcounter < 64)
        {
            index = Random.Range(0,16);
            tempcounter++;
        }
        if(tempcounter == 64)
        {
            script.EndGame();
        }
        else
        {
            GameObject newTile = Instantiate(tilePrefab, points[index].transform.position, Quaternion.identity, this.transform);
            TileScript newScript = newTile.GetComponent<TileScript>();
            newScript.point = points[index];
            points[index].inUse = true;
            points[index].currentTile = newTile;
            int tempVal = (int)Mathf.Pow(2, Random.Range(1,maxPow+1));
            if(tempVal>2)
            {
                //sets new tile's value and sprite, if more than the default
                newScript.value = tempVal;
                SpriteRenderer tempSprRend = newTile.GetComponent<SpriteRenderer>();
                tempSprRend.sprite = Resources.Load<Sprite>(tempVal + "Tile");
            }
            numTiles++;
        }
        validMoveTaken = false;
    }
}
