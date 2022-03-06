using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunEnemy : MonoBehaviour
{
    
    private float fireTimer = 0;        //Timer to manage firing
    private float patternTimer = 3;     //manage current pattern
    public GameObject bullet;       //Create a bullet object
    private Rigidbody2D rb2d;       //Create rigidbody
    private GameObject player;
    private int pattern = 0;
    private bool flurry = false;
    private bool aimed = false;
    private float maxHealth = 10.0f;
    private float currentHealth = 10.0f;
    private Slider slider;
  
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        slider = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<Slider>();
        slider.value = currentHealth;
        slider.maxValue = maxHealth;

    }

    private void Start()
    {
        slider = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<Slider>();
        slider.value = currentHealth;
        slider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //fire bullets
        //if fire rate time is achieved
        fireTimer += Time.deltaTime;
        patternTimer += Time.deltaTime;

        if (aimed)
        {
            if(fireTimer > 1)
            {
                fireTimer = 0;
                aimedShots();
            }
        }

        if (flurry)
        {
            if(fireTimer > 1/3f)
            {
                fireTimer = 0;
                buckShot();
            }
        }


        if (patternTimer > 5)
        {
            patternTimer = 0;

            switch (pattern)
            {
                case 0:
                    aimed = true;
                    break;
                case 1:
           
                    aimed = false;
                    flurry = true;
                    break;
                case 2:
                    flurry = false;
                    pattern = -1;
                    break;
            }
            pattern++;
      
        }
    }

    private void aimedShots()
    {
        transform.LookAt(player.transform.position);
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));


        Instantiate(bullet, transform.position, transform.rotation);
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle - 105)));
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle - 75)));
    }

    private void buckShot()
    {
        transform.LookAt(player.transform.position);
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));


        Instantiate(bullet, transform.position, transform.rotation);
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle - 105)));
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle - 75)));
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle - 120)));
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle - 60)));
    }

    public void takedamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").SendMessage("removeEnemy");
        }
            

        slider.value = currentHealth;

    }
}
