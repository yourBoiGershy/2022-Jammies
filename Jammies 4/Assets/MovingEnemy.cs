using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{

    private float fireRate = 1;                         //firerate
    private float fireTimer = 0;                        //timer for shooting
    public GameObject bullet;                           //bullet object to be fired
    private Rigidbody2D rb2d;                           //Create rigidbody
    private float movespeed = 3f;                       //enemy movespeed
    private Vector3 move = new Vector3(1f, 0f, 0f);     //movement vector
    private float timer = 0;                            //timer for changing direction
    private float directionTimer = 3;                   //timer goal

    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > 1 / fireRate)
        {
            fireTimer = 0;
            Vector3 playerPosition = transform.position;
            Instantiate(bullet, playerPosition, transform.rotation * Quaternion.Euler(180f, 0f, 0f));
        }

        timer += Time.deltaTime;
        if (timer > directionTimer)
        {
            timer = 0;
            move.x *= -1;
        }

        Vector3 translation = move * movespeed * Time.fixedDeltaTime;
        Vector3 newPosition = transform.position + translation;


        rb2d.MovePosition(newPosition);

    }
}
