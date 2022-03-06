using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwinshotEnemy : MonoBehaviour
{
    private float fireTimer = 0;        //Timer to manage firing
    private float aimTimer = 0;
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

    private static int i = 0;              //tracker for bouncing shots

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
        aimTimer += Time.deltaTime;

        if (aimed)
        {
            if (aimTimer > 1)
            {
                aimTimer = 0;
                aimedShots();
            }
        }

        if (flurry)
        {
            if (fireTimer > 1/10f)
            {
                fireTimer = 0;
                circleSpray(i);
                i++;
            }
        }


        if (patternTimer > 5)
        {
            patternTimer = 0;

            switch (pattern)
            {
                case 0:
                    aimed = true;
                    flurry = false;
                    break;
                case 1:
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    aimed = false;
                    flurry = true;
                    break;
                case 2:
                    i = 0;
                    aimed = true;
                    pattern = -1;
                    break;
            }
            pattern++;

        }
    }

    void aimedShots()
    {
        transform.LookAt(player.transform.position);
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));


        Instantiate(bullet, transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation);
        Instantiate(bullet, transform.position-new Vector3(0f,0.5f,0f), transform.rotation);
        
    }

    void circleSpray(int i)
    {
        
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 90 + (10 * (i%18)))));
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 270 - (10 * (i%18)))));
        
        
        
    }

    public void takedamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").SendMessage("removeEnemy");
        }

        slider.value = currentHealth;

    }
}
