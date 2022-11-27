using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSimpleMove : MonoBehaviour
{
    //The asteroid's horizontal speed
    public float speedX;
    //The asteroid's vertical speed;
    public float speedY;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(speedX * Time.deltaTime, speedY * Time.deltaTime));
    }
}
