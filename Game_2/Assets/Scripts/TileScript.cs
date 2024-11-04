using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public GameObject point;
    private SpriteRenderer sprRend;
    private TileManager script;
    
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
        Rigidbody2D otherBody = other.GetComponent<Rigidbody2D>();
        if (other.tag == "Tile" && other.GetComponent<TileScript>().value == value && notYetMerged)
        {
            script.validMoveTaken = true;
            if (otherBody.velocity.magnitude > body.velocity.magnitude)
            {
                value = value + value; //change for different logic
                script.addScore(value); //adds score
                notYetMerged = false;
                sprRend.sprite = Resources.Load<Sprite>(value + "Tile");
                Destroy(other.gameObject);
                body.velocity = new Vector2(0, 0);
                transform.position = point.transform.position;
            }
        }
        else if (other.tag == "Point")
        {
            script.validMoveTaken = true;
            point = other.gameObject;
        }
        else
        {
            body.velocity = new Vector2(0, 0);
            transform.position = point.transform.position;
            notYetMerged = true;
        }
    }
}
