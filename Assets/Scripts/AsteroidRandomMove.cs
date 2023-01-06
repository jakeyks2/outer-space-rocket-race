using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRandomMove : MonoBehaviour
{
    //The radius of the circle the target point should be on
    public float distance;
    //The time the asteroid should take to reach its target point
    public float travelTime;

    //The radius of the asteroid's path
    float travelRadius;
    //The point the asteroid starts at
    Vector2 startPoint;
    //The angle the asteroid is in relation to the midpoint between the start and target points
    float startAngle;
    //The target point. This will be a random point on the edge of a circle with its centre being the asteroid's position and a radius of "distance"
    Vector2 targetPoint;
    //The time since the asteroid last hit its target
    float timeSinceLastTarget;
    //Whether the asteroid should travel clockwise
    bool clockwise = false;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the initial start and target points to the asteroid's starting position
        startPoint = new Vector2(transform.position.x, transform.position.y);
        targetPoint = new Vector2(transform.position.x, transform.position.y);
        //Sets the radius of the asteroid's travel circle to half the "distance"
        travelRadius = distance / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the asteroid has reached its target
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetPoint) < 0.01)
        {
            //Inverts the asteroid's direction
            clockwise = !clockwise;
            //Resets the timer
            timeSinceLastTarget = 0;
            // Selects a random angle
            float angle = Random.Range(Mathf.PI * 0.0f, Mathf.PI * 2.0f);
            startPoint = new Vector2(transform.position.x, transform.position.y);
            //Sets the target point based on a conversion from polar to cartesian coordinates
            targetPoint = new Vector2(distance * Mathf.Cos(angle), distance * Mathf.Sin(angle)) + startPoint;
            //Calculates the angle around the circle the asteroid is starting at
            startAngle = Mathf.Deg2Rad * (Vector2.SignedAngle(Vector2.right * travelRadius, startPoint - (startPoint + targetPoint) / 2)) % 360.0f;
        }

        //Increases the timer
        timeSinceLastTarget += Time.deltaTime;
        //Updates the progress around the circle based on the timer
        float progress = timeSinceLastTarget / (travelTime * 2);
        //Turns the progress percentage into an angle around the circle
        float progressAngle = startAngle + progress * (clockwise ? -Mathf.PI : Mathf.PI);

        //Moves the asteroid around the circle
        transform.position = new Vector2(travelRadius * Mathf.Cos(progressAngle), travelRadius * Mathf.Sin(progressAngle)) + (startPoint + targetPoint) / 2;
    }
}
