using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCircleMove : MonoBehaviour
{
    //The speed of rotation
    public float speed;
    //The distance from the centre point
    public float length;
    //The centre point of rotation
    Vector2 centre;
    //The current angle from the centre point
    float angle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the centre of the circle's rotation to the position it starts in when play begins
        centre = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Increase the angle by the speed. Multiplying by deltaTime ensures the rotation speed is unaffected by frame rate
        angle += speed * Time.deltaTime;
        //Sets the position of the asteroid based on the formula for converting between polar and cartesian coordinates
        transform.position = new Vector2(length * Mathf.Sin(angle), length * Mathf.Cos(angle)) + centre;
    }
}
