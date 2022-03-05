using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    //Player movement Vector
    private Vector3 move = Vector3.zero;
    //Player movespeed
    public float speed = 5.0f;
    //Player fire rate
    private float fireRate = 3;
    //Track time the last bullet was fired 
    private float lastFired;
    //Create a bullet object
    public GameObject bullet;
    //Create rigidbody
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //player movement 

        //check if a/d/left/right was pressed and move player accordingly
        float rawHorizontalAxis = Input.GetAxisRaw("Horizontal");
        move.x = rawHorizontalAxis;

        //check if w/s/up/down was pressed and move player accordingly
        float rawVerticalAxis = Input.GetAxisRaw("Vertical");
        move.y = rawVerticalAxis;

        //fire bullets

        //if fire rate time is achieved
        if (Time.time - lastFired > 1 / fireRate)
        {
            lastFired = Time.time;
            Vector3 playerPosition = transform.position;
            Instantiate(bullet, playerPosition, Quaternion.identity);

        }
    }

    private void FixedUpdate()
    {

        //move player 

        //if there is movement on the vector, translate player
        if (move != Vector3.zero)
        {

            Vector3 translation = move * speed * Time.fixedDeltaTime;
            Vector3 newPosition = transform.position + translation;


            rb2d.MovePosition(newPosition);
        }
    }
}
