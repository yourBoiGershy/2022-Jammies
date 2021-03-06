using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
 
public class Player : MonoBehaviour
{

    private Vector3 move = Vector3.zero;            //Player movement Vector
    public float speed = 5.0f;                      //Player movespeed  
    private float fireRate = 3;                     //Player fire rate
    private float lastFired;                        //Track time the last bullet was fired 
    public GameObject bullet;                       //Create a bullet object
    private Rigidbody2D rb2d;                       //Create rigidbody

                       
    private int maxHealth = 3;
    private float currentHealth = 3;

    private static Weapon originalWeapon = new DefaultWeapon();
    private static Weapon shotgun = new ShotgunWeapon();
    private Weapon weapon = originalWeapon;                     //Type of weapon  

    public HealthBar healthBar;
    public int numberOfEnemies;

    private Slider slider; 
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        slider = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
        slider.value = currentHealth;
        slider.maxValue = maxHealth;
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        //slider.maxValue = 5;
        Debug.Log(numberOfEnemies);
    }

    private void Start()
    {
        {
            slider = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
            slider.value = currentHealth;
            slider.maxValue = maxHealth;
        }

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

            if (newPosition.x > -20 && newPosition.x < 20 && newPosition.y > -11 && newPosition.y < 11)
                rb2d.MovePosition(newPosition);
        }
    }

    void takedamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
            //Destroy(currentHealth);
        }
        //slider = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
        slider.value = currentHealth;
       
    }

    void updateCurrentHealth(float health)
    {
        currentHealth = health;
    }

    void removeEnemy()
    {
        numberOfEnemies -= 1;
        Debug.Log(numberOfEnemies);
        if (numberOfEnemies <= 0)
        {
            if(SceneManager.GetActiveScene().buildIndex != 12){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }
    }

    
}
