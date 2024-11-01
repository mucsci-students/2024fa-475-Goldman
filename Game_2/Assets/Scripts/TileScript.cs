using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private Vector3 point;
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
                //change for different logic
                value = value * 2;
                notYetMerged = false;
                sprRend.sprite = Resources.Load<Sprite>(value + "Tile");
                Destroy(other.gameObject);
            }
        }
        else if (other.tag == "Point")
        {
            point = other.GetComponent<Transform>().position;
            script.validMoveTaken = true;
        }
        else
        {
            body.velocity = new Vector2(0, 0);
            transform.position = point;
            notYetMerged = true;
        }
    }
}
