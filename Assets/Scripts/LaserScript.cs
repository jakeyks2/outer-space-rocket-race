using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    //The speed the laser should move at
    public Vector2 velocity;
    //The laser's rigidbody component
    public Rigidbody2D rb;
    //The laser particle
    public GameObject particles;
    public Player owningPlayerScript;

    void FixedUpdate()
    {
        //Scales based on time between updates
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    //When the asteroid can't be seen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //When the laser collides with an asteroid
        if (collision.gameObject.tag == "Obstacle")
        {
            collision.gameObject.GetComponent<Asteroid>().TakeDamage(1);
            //Creates laser particles
            Instantiate(particles, transform.position, Quaternion.identity);
            //Increases the player's score
            owningPlayerScript.Score += 10;
            Destroy(gameObject);
        }
    }
}
