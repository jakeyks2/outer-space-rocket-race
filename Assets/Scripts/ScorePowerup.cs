using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePowerup : Powerup
{
    public float score;

    public override void OnPickup(GameObject player)
    {
        player.GetComponent<Player>().Score += score;
    }
}
