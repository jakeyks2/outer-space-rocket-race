using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPowerup : Powerup
{
    public float cooldownReduction;

    public override void OnPickup(GameObject player)
    {
        player.GetComponent<ShipShooting>().laserCooldown -= cooldownReduction;
    }

    public override void OnTimeout(GameObject player)
    {
        player.GetComponent<ShipShooting>().laserCooldown += cooldownReduction;
        base.OnTimeout(player);
    }
}
