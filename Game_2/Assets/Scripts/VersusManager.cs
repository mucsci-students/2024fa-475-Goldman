using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersusManager : MonoBehaviour
{ /*
    private float player1Timer;
    private float player2Timer;
    private int speed = 30;
    private int numPoints = 16;
    private int boardLength = 4;
    private float waitTime = 0.3f;
    public int numTiles;

    public Manager script;
    public TileManager player1;
    public TileManager player2;

    void Start()
    {
        player1Timer = 0;
        player2Timer = 0;
    }
    void Update()
    {
        if (Time.deltaTime == 0)
        {
            return;
        }
        player1Timer += Time.deltaTime;
        player2Timer += Time.deltaTime;
        if (player1Timer > waitTime)
        {
            if (Player1MoveTaken())
            {
                player1Timer = 0;
                StartCoroutine(player1.SpawnTile());
                StartCoroutine(player2.SpawnTile());
            }
        }
        if (player2Timer> waitTime)
        {
            if (Player2MoveTaken())
            {
                player2Timer = 0;
                StartCoroutine(player2.SpawnTile());
                StartCoroutine(player1.SpawnTile());
            }
        }

    }
    //returns false if no move taken, if one is taken, moves all tiles
    bool Player1MoveTaken()
    {
        if (player1.numTiles == numPoints && player1.NoMoves())
        {
            player1.track.SaveScore();
            script.EndGame();
            return false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            player1.direction = new Vector2(0, speed);
            StartCoroutine(player1.MoveTiles(boardLength, numPoints, boardLength, boardLength, 1));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            player1.direction = new Vector2(-speed, 0);
            StartCoroutine(player1.MoveTiles(1, boardLength, 1, numPoints, boardLength));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            player1.direction = new Vector2(0, -speed);
            StartCoroutine(player1.MoveTiles(numPoints - (2 * boardLength), numPoints, -boardLength, boardLength, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player1.direction = new Vector2(speed, 0);
            StartCoroutine(player1.MoveTiles(boardLength - 2, boardLength, -1, numPoints, 4));
        }
        else
        {
            player1.direction = new Vector2(0, 0);
            return false;
        }
        return true;
    }

    bool Player2MoveTaken()
    {
        if (player2.numTiles == numPoints && player2.NoMoves())
        {
            player2.track.SaveScore();
            script.EndGame();
            return false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player2.direction = new Vector2(0, speed);
            StartCoroutine(player2.MoveTiles(boardLength, numPoints, boardLength, boardLength, 1));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player2.direction = new Vector2(-speed, 0);
            StartCoroutine(player2.MoveTiles(1, boardLength, 1, numPoints, boardLength));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player2.direction = new Vector2(0, -speed);
            StartCoroutine(player2.MoveTiles(numPoints - (2 * boardLength), numPoints, -boardLength, boardLength, 1));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player2.direction = new Vector2(speed, 0);
            StartCoroutine(player2.MoveTiles(boardLength - 2, boardLength, -1, numPoints, 4));
        }
        else
        {
            player2.direction = new Vector2(0, 0);
            return false;
        }
        return true;
    }
    */
}
