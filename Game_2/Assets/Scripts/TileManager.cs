using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private float timer;
    private int speed = 20;
    private int maxPow = 2;
    private float waitTime = 0.3f;
    private int moveCounter;

    public int numTiles;
    public bool validMoveTaken;
    public Vector2 direction;

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
        if (Time.deltaTime == 0)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            if (MoveTaken())
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
    bool MoveTaken()
    {
        if (numTiles == 16 && NoMoves())
        {
            timer = 0;
            script.EndGame();
            return false;
        }
        //gets list of all points
        PointScript[] pointList = GetComponentsInChildren<PointScript>();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = new Vector2(0, speed);
            //StartCoroutine(MoveTiles(0, 16, 4, 4, 1));
            foreach (PointScript point in pointList)
            {
                if (point.currentTile != null)
                {
                    point.currentTile.GetComponent<Rigidbody2D>().velocity = direction;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = new Vector2(-speed, 0);
            //StartCoroutine(MoveTiles(3, 4, -1, 16, 4));
            for (int i = 0; i < 4; i++)
            {//iterate right by columns
                for (int j = i; j < 16; j += 4)
                {
                    if (pointList[j].currentTile != null)
                    {
                        pointList[j].currentTile.GetComponent<Rigidbody2D>().velocity = direction;
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = new Vector2(0, -speed);
            //StartCoroutine(MoveTiles(12, 13, -4, 4, 1));
            for (int i = 12; i >= 0; i -= 4)
            {//iterate up by rows
                for (int j = i; j < i + 4; j++)
                {
                    if (pointList[j].currentTile != null)
                    {
                        pointList[j].currentTile.GetComponent<Rigidbody2D>().velocity = direction;
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = new Vector2(speed, 0);
            //StartCoroutine(MoveTiles(3, 4, -1, 16, 4));
            for (int i = 3; i >= 0; i--)
            {//iterate left by columns
                for (int j = i; j < 16; j += 4)
                {
                    if (pointList[j].currentTile != null)
                    {
                        pointList[j].currentTile.GetComponent<Rigidbody2D>().velocity = direction;
                    }
                }
            }
        }
        else
        {
            direction = new Vector2(0, 0);
            return false;
        }
        return true;
        //gets all tiles under object
    }
    //checks if any valid moves left
    bool NoMoves()
    {
        TileScript[] scripts = GetComponentsInChildren<TileScript>();
        foreach (TileScript TS in scripts)
        {
            foreach (Vector2 vec in new Vector2[] { Vector2.up, Vector2.right })
            {
                RaycastHit2D hit = Physics2D.Raycast(TS.transform.position, vec);
                if (hit.collider != null && hit.collider.tag == "Tile")
                {
                    if (hit.collider.GetComponent<TileScript>().value == TS.value)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    IEnumerator MoveTiles(int iStart, int iEnd, int iInc, int jEnd, int jInc)
    {
        PointScript[] pointList = GetComponentsInChildren<PointScript>();
        for (int i = iStart; i >= 0 && i < iEnd; i += iInc)
            {//iterate left by columns
                for (int j = i; j < 16 && j < i + jEnd; j += jInc)
                {
                    if (pointList[j].currentTile != null)
                    {
                        pointList[j].currentTile.GetComponent<Rigidbody2D>().velocity = direction;
                    }
                }
            }
        yield break;
    }

    //spawns in tile at a random unused point
    IEnumerator SpawnTile()
    {
        yield return new WaitForSeconds(waitTime - 0.1f);
        if (!validMoveTaken && moveCounter > 0)
        {
            yield break;
        }
        moveCounter++;
        PointScript[] points = GetComponentsInChildren<PointScript>();
        int index = Random.Range(0, 16);
        //once counter hits 40 assume that board is full
        int tempcounter = 0;
        while (points[index].inUse && tempcounter < 128)
        {
            index = Random.Range(0, 16);
            tempcounter++;
        }
        if (tempcounter == 128)
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
            int tempVal = (int)Mathf.Pow(2, Random.Range(1, maxPow + 1));
            if (tempVal > 2)
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
