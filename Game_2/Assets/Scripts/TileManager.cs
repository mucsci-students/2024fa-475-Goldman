using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private float timer = 0f;
    private int speed = 20;
    private int maxPow = 2;
    private float waitTime = 0.3f;

    public bool validMoveTaken = false;

    public Manager script;
    public ScoreTracker track;
    public GameObject tilePrefab;

    void Start()
    {
       //StartCoroutine(SpawnTile());
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
        if(Input.GetKeyDown(KeyCode.W))
        {
            yVel = speed;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            xVel = -speed;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            yVel = -speed;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            xVel = speed;
        }
        else
        {
            return false;
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
        yield return new WaitForSeconds(.2f);
        PointScript[] points = GetComponentsInChildren<PointScript>();
        int index = Random.Range(0,16);
        //change later once fullboard done
        int tempcounter = 0;
        while (points[index].inUse && tempcounter < 40)
        {
            //0 through 15,as last value is not counted for (int)range
            index = Random.Range(0,16);
            tempcounter++;
        }
        if(tempcounter == 40)
        {
            script.EndGame();
        }
        else
        {
            GameObject newTile = Instantiate(tilePrefab, points[index].transform.position, Quaternion.identity, this.transform);                //last value isn't counted so one is added
            int tempVal = (int)Mathf.Pow(2, Random.Range(1,maxPow+1));
            if(tempVal>2)
            {
                //sets new tile's value and sprite, if more than the default
                newTile.GetComponent<TileScript>().value = tempVal;
                SpriteRenderer tempSprRend = newTile.GetComponent<SpriteRenderer>();
                tempSprRend.sprite = Resources.Load<Sprite>(tempVal + "Tile");
            }
        }
    }
}
