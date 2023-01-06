using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupEffect : MonoBehaviour
{
    //The player who collected the powerup
    private GameObject player;
    public GameObject Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }

    //The sprite of the powerup
    private Sprite sprite;
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
        set
        {
            sprite = value;
        }
    }

    //The length the powerup should last
    private float duration;
    public float Duration
    {
        get
        {
            return duration;
        }
        set
        {
            duration = value;
        }

    }

    //The function to run when the powerup is picked up
    private Action<GameObject> onPickup;
    public Action<GameObject> OnPickup
    {
        get
        {
            return onPickup;
        }
        set
        {
            onPickup = value;
        }

    }

    //The function to run when the powerup's duration hits 0
    private Action<GameObject> onTimeout;
    public Action<GameObject> OnTimeout
    {
        get
        {
            return onTimeout;
        }
        set
        {
            onTimeout = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        OnPickup(player);
    }

    // Update is called once per frame
    void Update()
    {
        //Reduces the remaining duration
        Duration -= Time.deltaTime;
        if (Duration <= 0)
        {
            //Removes the powerup from the player
            player.GetComponent<Player>().CurrentPowerups.Remove(gameObject);
            OnTimeout(player);
            Destroy(gameObject);
        }
    }
}
