using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeapon : Weapon
{    
    public override void fire(Player player, GameObject bullet)
    {
        GameObject.Instantiate(bullet, player.transform.position, player.transform.rotation);
    }
}
