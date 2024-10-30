using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float timer = 0f;
    private int speed = 2;
    public Manager script;

    void Start()
    {
       // body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Time.deltaTime == 0){
            return;
        }
        timer += Time.deltaTime;
        if(timer > 1f)
        {
            timer = 0;
            Move();
        }
        
    }
    void Move()
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
        Rigidbody2D[] children = GetComponentsInChildren<Rigidbody2D>();
        foreach(Rigidbody2D body in children)
        {
            body.velocity = new Vector2(xVel, yVel);
        }
    }

}
