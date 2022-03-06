using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerBullet : MonoBehaviour
{

    //bullet speed
    public float speed = 10.0f;
    //create rigidbody component
    private Rigidbody2D rb2d;
    //create a vector that only moves upwards (player's bullet can only move in one direction)
    private Vector3 move = Vector3.down;



    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collision occured");
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("takedamage", 0.25);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move the bullet
        transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);

        float xCoordinate = transform.position.x;
        float yCoordinate = transform.position.y;

        //Debug.Log("x coordinate: " + xCoordinate + " y coordinate: " + yCoordinate);
        if (xCoordinate < -22 || xCoordinate > 22 || yCoordinate < -9.5 || yCoordinate > 12)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        //if the bullet moved, update the rigidbody to follow it
        if(move != Vector3.zero)
        {
            Vector3 translation = move * speed * Time.fixedDeltaTime;
            Vector3 newPosition = transform.position + translation;
            rb2d.MovePosition(newPosition);
        }
    }
}
