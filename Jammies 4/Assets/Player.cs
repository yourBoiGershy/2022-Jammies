using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    
    private Vector3 move = Vector3.zero;            //Player movement Vector
    public float speed = 5.0f;                      //Player movespeed  
    private float fireRate = 3;                     //Player fire rate
    private float lastFired;                        //Track time the last bullet was fired 
    public GameObject bullet;                       //Create a bullet object
    private Rigidbody2D rb2d;                       //Create rigidbody
    public Weapon weapon = new DefaultWeapon();                           //Type of weapon

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
            weapon.fire(this, bullet);
            
            //Instantiate(bullet, playerPosition, Quaternion.identity);

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
