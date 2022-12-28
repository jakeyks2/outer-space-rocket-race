using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRandomMove : MonoBehaviour
{
    public float distance;
    public float travelTime;

    float travelRadius;
    Vector2 startPoint;
    float startAngle;
    Vector2 targetPoint;
    float timeSinceLastTarget;
    bool clockwise = false;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = new Vector2(transform.position.x, transform.position.y);
        targetPoint = new Vector2(transform.position.x, transform.position.y);
        travelRadius = distance / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetPoint) < 0.01)
        {
            clockwise = !clockwise;
            timeSinceLastTarget = 0;
            float angle = Random.Range(Mathf.PI * 0.0f, Mathf.PI * 2.0f);
            startPoint = new Vector2(transform.position.x, transform.position.y);
            targetPoint = new Vector2(distance * Mathf.Cos(angle), distance * Mathf.Sin(angle)) + startPoint;
            startAngle = Mathf.Deg2Rad * (Vector2.SignedAngle(Vector2.right * travelRadius, startPoint - (startPoint + targetPoint) / 2)) % 360.0f;
        }

        timeSinceLastTarget += Time.deltaTime;
        float progress = timeSinceLastTarget / (travelTime * 2);
        float progressAngle = startAngle + progress * (clockwise ? -Mathf.PI : Mathf.PI);

        transform.position = new Vector2(travelRadius * Mathf.Cos(progressAngle), travelRadius * Mathf.Sin(progressAngle)) + (startPoint + targetPoint) / 2;
    }
}
