using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFollow : MonoBehaviour
{
    public GameObject player;
    public float travelTimeFactor;

    float travelRadius;
    Vector2 startPoint;
    float startAngle;
    Vector2 targetPoint;
    float timeSinceLastTarget;
    bool clockwise = false;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = new Vector2(transform.position.x, transform.position.y);
        targetPoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 15)
        {
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetPoint) < 0.01)
            {
                clockwise = !clockwise;
                timeSinceLastTarget = 0;
                startPoint = new Vector2(transform.position.x, transform.position.y);
                targetPoint = new Vector2(player.transform.position.x, player.transform.position.y);
                distance = Vector2.Distance(startPoint, targetPoint);
                travelRadius = distance / 2.0f;
                startAngle = Mathf.Deg2Rad * (Vector2.SignedAngle(Vector2.right * travelRadius, startPoint - (startPoint + targetPoint) / 2)) % 360.0f;
            }

            timeSinceLastTarget += Time.deltaTime;
            float progress = timeSinceLastTarget / (travelTimeFactor * distance);
            float progressAngle = startAngle + progress * (clockwise ? -Mathf.PI : Mathf.PI);

            transform.position = new Vector2(travelRadius * Mathf.Cos(progressAngle), travelRadius * Mathf.Sin(progressAngle)) + (startPoint + targetPoint) / 2;
        }
    }
}
