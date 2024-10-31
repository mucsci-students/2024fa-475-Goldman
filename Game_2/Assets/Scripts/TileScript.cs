using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] public float value;

    public Rigidbody2D body;
    public Vector3 point;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D otherBody = other.GetComponent<Rigidbody2D>();
        if (other.tag == "Tile" && other.GetComponent<TileScript>().value == value)
        {
            if(otherBody.velocity.magnitude > body.velocity.magnitude){
                //change for different logic
                value *=2;
                Destroy(other.gameObject);
            }
        }
        else if (other.tag == "Point" )
        {
            point = other.GetComponent<Transform>().position;
        }
        else
        {
            body.velocity = new Vector2(0, 0);
            transform.position = point;
        }
    }
}
