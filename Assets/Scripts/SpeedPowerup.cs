using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : Powerup
{
    //The speed the timer should go at while active
    public float timeSlow;

    //Sets the timer to go slower
    public override void OnPickup(GameObject player)
    {
        player.GetComponent<Player>().TimerSpeed = timeSlow;
    }

    //Resets the timer to 1 second per second
    public override void OnTimeout(GameObject player)
    {
        player.GetComponent<Player>().TimerSpeed = 1;
        base.OnTimeout(player);
    }
}
