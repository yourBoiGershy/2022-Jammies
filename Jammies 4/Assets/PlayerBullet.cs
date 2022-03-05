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
        Debug.Log("collision occured");
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
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
        if(move != Vector3.zero)
        {
            Vector3 translation = move * speed * Time.fixedDeltaTime;
            Vector3 newPosition = transform.position + translation;
            rb2d.MovePosition(newPosition);
        }
    }
}
