using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPowerup : Powerup
{
    //The amount of reduction to be applied to the player's shooting cooldown
    public float cooldownReduction;

    //Reduces the cooldown when picked up
    public override void OnPickup(GameObject player)
    {
        player.GetComponent<ShipShooting>().laserCooldown -= cooldownReduction;
    }

    //Increases the cooldown when timing out
    public override void OnTimeout(GameObject player)
    {
        player.GetComponent<ShipShooting>().laserCooldown += cooldownReduction;
        base.OnTimeout(player);
    }
}
