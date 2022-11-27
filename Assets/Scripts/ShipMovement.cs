using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //The horizontal speed the ship will move at
    public float speedX;
    //The vertical speed the ship will move at
    public float speedY;

    //The ship's Rigidbody 2D
    public Rigidbody2D rb;

    //The vector the ship will move towards. Initialised as zero i.e. no movment
    Vector2 movementVector = Vector2.zero;

    void FixedUpdate()
    {
        /* Sets each component of the movement vector as the product of the time since the last frame,
         * the axis value in the direction and the speed in the direction. The time since last frame is
         * used to ensure that the ship moves at a constant speed regardless of frame rate */
        movementVector = new Vector2(Input.GetAxis("Horizontal") * speedX * Time.fixedDeltaTime, Input.GetAxis("Vertical") * speedY * Time.fixedDeltaTime);
        //Moves the ship according to the vector
        rb.MovePosition(rb.position + movementVector);
        //If the ship is moving
        if (movementVector.magnitude > 0)
        {
            //Rotate the ship to face its movement
            rb.MoveRotation(Quaternion.LookRotation(Vector3.forward, movementVector));
        }
    }
}
