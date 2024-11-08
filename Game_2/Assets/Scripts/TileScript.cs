using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private SpriteRenderer sprRend;
    private TileManager script;
    public PointScript point;
    
    [SerializeField] public int value;
    [HideInInspector] public Rigidbody2D body;
    
    public bool notYetMerged = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
        script = transform.parent.GetComponent<TileManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Tile" && other.GetComponent<TileScript>().value == value && notYetMerged && other.GetComponent<TileScript>().notYetMerged)
        {
            script.validMoveTaken = true;
            if (KeepTile(other))
            {
                TileMerge(other);
                StartCoroutine(AllowMerge());
            }
        }
        else if (other.tag == "Point")
        {
            //only valid move if a new point is hit, not the current one
            if(body.velocity.magnitude > 0 && other.GetComponent<PointScript>().currentTile != this.gameObject)
            {
               script.validMoveTaken = true;
            }
            if(point.currentTile == this.gameObject)
            {
                point.inUse = false;
                point.currentTile = null;
            }
            point = other.GetComponent<PointScript>();
            point.currentTile = this.gameObject;
            point.inUse = true;
        }
        else
        {
            body.velocity = new Vector2(0, 0);
            transform.position = point.transform.position;
        }
    }
    /* checks if this tile should remain from merging with another, if in direction of movement
     * ex: if tile is on left when both are moving left, then keep it and delete the other
    */
    bool KeepTile(Collider2D other)
    {
        float velX = script.direction.x;
        float velY = script.direction.y;
        //check if this tile and movement are left or this tile and movement are right
        if(transform.position.x < other.transform.position.x && velX < 0 || transform.position.x > other.transform.position.x && velX > 0)
        {
            return true;
        }
        //check if this tile and movement are up or this tile and movement are down
        if(transform.position.y < other.transform.position.y && velY < 0 || transform.position.y > other.transform.position.y && velY > 0)
        {
            return true;
        }
        return false;
    }
    //updates tile with new values and deletes old one
    void TileMerge(Collider2D other)
    {   
        if(!notYetMerged || !other.GetComponent<TileScript>().notYetMerged)
        {
            return;
        }
        value = value + value; //change for different logic
        script.addScore(value); //adds score
        script.numTiles--;
        notYetMerged = false;
        other.GetComponent<TileScript>().notYetMerged = false;
        //resets other tile's point
        PointScript otherPoint = other.GetComponent<TileScript>().point;
        if(otherPoint.currentTile == other.gameObject)
        {
            otherPoint.inUse = false;
            otherPoint.currentTile = null;
        }
        Destroy(other.gameObject);
        //updates tile to new values
        sprRend.sprite = Resources.Load<Sprite>(value + "Tile");
        body.velocity = new Vector2(0, 0);
        transform.position = point.transform.position;
    }
    IEnumerator AllowMerge()
    {
        yield return new WaitForSeconds(0.2f);
        notYetMerged = true;
    }
}
