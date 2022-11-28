using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupEffect : MonoBehaviour
{
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
        Duration -= Time.deltaTime;
        if (Duration <= 0)
        {
            player.GetComponent<Player>().CurrentPowerups.Remove(gameObject);
            OnTimeout(player);
            Destroy(gameObject);
        }
    }
}
