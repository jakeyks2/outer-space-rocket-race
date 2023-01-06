using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFollow : MonoBehaviour
{
    //The player the asteroid should follow
    public GameObject player;
    //The speed at which the asteroid should follow the player
    public float travelTimeFactor;

    //The radius of the asteroid's path
    float travelRadius;
    //The point the asteroid starts at
    Vector2 startPoint;
    //The angle the asteroid is in relation to the midpoint between the start and target points
    float startAngle;
    //The player's position
    Vector2 targetPoint;
    //The time since the asteroid last hit its target
    float timeSinceLastTarget;
    //Whether the asteroid should travel clockwise
    bool clockwise = false;
    //The distance between the start and target points
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the initial start and target points to the asteroid's starting position
        startPoint = new Vector2(transform.position.x, transform.position.y);
        targetPoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //If the asteroid is within 15 units of the player. Ensures the asteroid only moves if the player can see it
        if (Vector2.Distance(transform.position, player.transform.position) < 15)
        {
            //Checks if the asteroid has reached its target position
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetPoint) < 0.01)
            {
                //Sets the asteroid to move the opposite direction
                clockwise = !clockwise;
                //Resets the timer
                timeSinceLastTarget = 0;
                //Updates the start point to the asteroid's position
                startPoint = new Vector2(transform.position.x, transform.position.y);
                //Updates the target point to the player's position
                targetPoint = new Vector2(player.transform.position.x, player.transform.position.y);
                //Updates the distance
                distance = Vector2.Distance(startPoint, targetPoint);
                /* Sets the travel radius to half the distance. This will be the radius of a circle with a centre of the midpoint between the start
                 * and target points and that has the start point on its edge */
                travelRadius = distance / 2.0f;
                //Calculates the angle around the aforementioned circle
                startAngle = Mathf.Deg2Rad * (Vector2.SignedAngle(Vector2.right * travelRadius, startPoint - (startPoint + targetPoint) / 2)) % 360.0f;
            }

            //Updates the timer
            timeSinceLastTarget += Time.deltaTime;
            //Updates the percent progress around the circle
            float progress = timeSinceLastTarget / (travelTimeFactor * distance);
            //Calculates the angle the asteroid should be at
            float progressAngle = startAngle + progress * (clockwise ? -Mathf.PI : Mathf.PI);

            //Sets the position of the asteroid based on the formula for converting between polar and cartesian coordinates
            transform.position = new Vector2(travelRadius * Mathf.Cos(progressAngle), travelRadius * Mathf.Sin(progressAngle)) + (startPoint + targetPoint) / 2;
        }
    }
}
