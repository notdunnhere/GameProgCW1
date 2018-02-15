using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {
    //the bouncing ball
    public GameObject ogball;
    //what the ball will bounce on
    public GameObject plane;
    public double radius = 1.9;

    //make the ball fall
    Vector3 gravity = new Vector3 (0, -9.81f, 0); 
    Vector3 bounce = new Vector3(0, -1f, 0);
    Vector3 friction = new Vector3(0,-2f,0);
    Vector3 velocity;
    Vector3 max_height = new Vector3 (0, 8.0f, 0);
    Vector3 min_height = new Vector3(0, 0, 0);


    public int timer;
    
    // Use this for initialization
    void Start()
    {
        //set timer to 0 at the beginning of the simulation
        timer = 0;
        //set intial position of ball
            ogball.transform.position = new Vector3(0, 9, 0);
        //set position of plane (doesn't change)
            plane.transform.position = new Vector3(0, 0, 0);
    }
    
    void Update()
    {  //empty
    }
    
    void FixedUpdate()
        {
        //increase timer
        timer++;
        velocity = velocity + gravity * Time.fixedDeltaTime;    //v = u + at; where a = gravity
       Vector3 speed = (max_height - min_height) / Time.fixedDeltaTime;

        speed = velocity;

        //if the ball coliides with the plane then make the ball go up
    if (ogball.transform.position.y - radius < plane.transform.position.y)
            {
            velocity.y = velocity.y - bounce.y; //+ friction.y;
            
            }

    //when the timer is at 380, delete the ball
        if (timer == 380) {
            //  Destroy(ogball);
           // max_height.y--;
        }

        //ball and colider movement based on new velocity
        ogball.transform.Translate(velocity * Time.fixedDeltaTime); 
    }}