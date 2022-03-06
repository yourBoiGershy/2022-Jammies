using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    
    public float speed = 10.0f;                 //bullet speed   
    private Rigidbody2D rb2d;                   //create rigidbody component  
    private Vector3 move = Vector3.down;        //create a vector that only moves upwards (enemy's bullet can only move in one direction)

    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //triggered on collision. param is what this collided with
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("takedamage", 0.4);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move the bullet
        transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
    }

    private void FixedUpdate()
    {
        //if the bullet moved, update the rigidbody to follow it
        if (move != Vector3.zero)
        {
            Vector3 translation = move * speed * Time.fixedDeltaTime;
            Vector3 newPosition = transform.position + translation;
            rb2d.MovePosition(newPosition);
        }
    }
}
