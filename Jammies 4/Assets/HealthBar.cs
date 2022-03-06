using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    // Start is called before the first frame update

    public void setHealth(float health)
    {
        slider = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
        Debug.Log(slider.value);
        slider.value = health;
    }

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    private void Start()
    {
        
    }
    

}
