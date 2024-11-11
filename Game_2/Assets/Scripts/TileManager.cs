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
            foreach (Vector2 vec in new Vector3[] { Vector2.up, Vector2.right })
            {
                RaycastHit2D hit = Physics2D.Raycast(TS.transform.position, vec);
                Debug.Log(hit.collider);
                if (hit.collider != null)
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
        while (points[index].inUse && tempcounter < 64)
        {
            index = Random.Range(0, 16);
            tempcounter++;
        }
        if (tempcounter == 64)
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
