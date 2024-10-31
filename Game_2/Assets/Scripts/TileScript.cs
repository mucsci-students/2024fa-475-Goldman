using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private SpriteRenderer sprRend;
    public bool notYetMerged = true;

    [SerializeField] public int value;

    public Rigidbody2D body;
    public Vector3 point;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string spriteName;
        Rigidbody2D otherBody = other.GetComponent<Rigidbody2D>();
        if (other.tag == "Tile" && other.GetComponent<TileScript>().value == value && notYetMerged)
        {
            if (otherBody.velocity.magnitude > body.velocity.magnitude)
            {
                //change for different logic
                value = value * 2;
                notYetMerged = false;
                spriteName = value + "Tile";
                sprRend.sprite = Resources.Load(spriteName) as Sprite;
                Destroy(other.gameObject);
            }
        }
        else if (other.tag == "Point")
        {
            point = other.GetComponent<Transform>().position;
        }
        else
        {
            body.velocity = new Vector2(0, 0);
            transform.position = point;
            notYetMerged = true;
        }
    }
}
