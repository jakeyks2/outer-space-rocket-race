using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePowerup : Powerup
{
    //The amount of score to add
    public float score;

    //When picked up, increases the player's score
    public override void OnPickup(GameObject player)
    {
        player.GetComponent<Player>().Score += score;
    }
}
