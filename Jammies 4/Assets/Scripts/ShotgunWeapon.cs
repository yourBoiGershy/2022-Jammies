using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : Weapon
{
    public override void fire(Player player, GameObject bullet)
    {
        GameObject.Instantiate(bullet, player.transform.position, Quaternion.Euler(new Vector3(0, 0, 15)));
        GameObject.Instantiate(bullet, player.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        GameObject.Instantiate(bullet, player.transform.position, Quaternion.Euler(new Vector3(0, 0, -15)));
    }
}
