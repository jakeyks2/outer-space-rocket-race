using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //The health the asteroid should start with
    public float startHealth;

    //The current health of the asteroid
    private float health;

    //A property for the health variable
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = startHealth;
    }

    //Called by the laser script when it hits the asteroid
    public void TakeDamage(float damage)
    {
        //Reduces the asteroid's health by the damage dealt by the laser
        Health -= damage;

        //When the asteroid is out of health, destroy it
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
