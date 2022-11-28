using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : Powerup
{
    public float speedBoost;

    public override void OnPickup(GameObject player)
    {
        player.GetComponent<ShipMovement>().speedX += speedBoost;
        player.GetComponent<ShipMovement>().speedY += speedBoost;
    }

    public override void OnTimeout(GameObject player)
    {
        player.GetComponent<ShipMovement>().speedX -= speedBoost;
        player.GetComponent<ShipMovement>().speedY -= speedBoost;
        base.OnTimeout(player);
    }
}
