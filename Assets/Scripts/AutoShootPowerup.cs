using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShootPowerup : Powerup
{
    public override void OnPickup(GameObject player)
    {
        player.GetComponent<ShipShooting>().AutoShoot = true;
        base.OnPickup(player);
    }

    public override void OnTimeout(GameObject player)
    {
        player.GetComponent<ShipShooting>().AutoShoot = false;
        base.OnTimeout(player);
    }
}
