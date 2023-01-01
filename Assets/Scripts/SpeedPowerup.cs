using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : Powerup
{
    public float timeSlow;

    public override void OnPickup(GameObject player)
    {
        player.GetComponent<Player>().TimerSpeed = timeSlow;
    }

    public override void OnTimeout(GameObject player)
    {
        player.GetComponent<Player>().TimerSpeed = 1;
        base.OnTimeout(player);
    }
}
