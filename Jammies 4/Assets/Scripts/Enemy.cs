using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public string enemyType;
    public int atk;
    public int hp;

    public Enemy()
    {
        enemyType = "";
        atk = 1;
        hp = 1;
    }

    public Enemy(string name, int attack, int health)
    {
        enemyType = name;
        atk = attack;
        hp = health;
    }
}
