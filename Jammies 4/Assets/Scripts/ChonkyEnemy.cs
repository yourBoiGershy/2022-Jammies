using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChonkyEnemy : MonoBehaviour
{

    private float fireRate = 0.8f;                      //firerate
    private float fireTimer = 0f;                       //timer for shooting
    public GameObject bullet;                           //bullet object to be fired
    private Rigidbody2D rb2d;                           //Create rigidbody

    private float maxHealth = 1;
    private float currentHealth = 1;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //fire (firerate) bullets per second
        fireTimer += Time.deltaTime;
        if(fireTimer > 1 / fireRate)
        {
            fireTimer = 0;
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(180f, 0f, 0f));
        }
    }

    public void takedamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            //Destroy(currentHealth);
        }
    }
}
