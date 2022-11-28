using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public Vector2 velocity;
    public Rigidbody2D rb;
    public GameObject particles;
    public Player owningPlayerScript;

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            collision.gameObject.GetComponent<Asteroid>().TakeDamage(1);
            Instantiate(particles, transform.position, Quaternion.identity);
            owningPlayerScript.Score += 10;
            Destroy(gameObject);
        }
    }
}
