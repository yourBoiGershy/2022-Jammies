using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    //Fire rate
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
        //fire bullets

        //if fire rate time is achieved
        if (Time.time - lastFired > 1 / fireRate)
        {
            lastFired = Time.time;
            Vector3 playerPosition = transform.position;
            Instantiate(bullet, playerPosition, transform.rotation * Quaternion.Euler(180f, 0f, 0f));

        }
    }
}
