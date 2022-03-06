using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    //Fire rate
    private float fireRate = 1f;
    //Track time the last bullet was fired 
    private float lastFired;
    //Create a bullet object
    public GameObject bullet;
    //Create rigidbody
    private Rigidbody2D rb2d;


    private float maxHealth = 1.00f;
    private float currentHealth;

    private Vector3 currentHealthPosition;

   

    private void Awake()
    {
        Vector3 healthPosition = new Vector3(0f, 5f, 0f);
        //Instantiate(maxHealth, transform.position + maxHealthPosition, Quaternion.identity);
        /*
        currentHealthPosition = new Vector3(0f, 0.8f, 0f);
        Instantiate(currentHealth, transform.position + currentHealthPosition, Quaternion.identity);
        currentHealth.transform.localScale = new Vector3(1, 0.2f, 0);
        */
        //Instantiate(healthBar, transform.position + healthPosition, Quaternion.identity);

        currentHealth = maxHealth;

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
      
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

        //currentHealth.transform.Translate(0f, 0f, 0f);
    }

    void takedamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            //Destroy(currentHealth);
        }
       
        

        //Debug.Log(currentHealth.transform.localScale.x);
        
        //currentHealth.transform.localScale -= new Vector3(damage, 0.0f, 0.0f);

        //currentHealth.transform.Translate(-damage / 2, 0.0f, 0.0f);
     
        
        
        
        //Debug.Log("Hp left: " + health);
    }
}
