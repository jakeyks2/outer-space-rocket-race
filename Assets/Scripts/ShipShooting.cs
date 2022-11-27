using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    public string fireKey;
    public GameObject laserPrefab;
    public float laserSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(fireKey))
        {
            Instantiate(laserPrefab, transform.position, transform.rotation).GetComponent<LaserScript>().velocity = DegreesToVector(transform.rotation.eulerAngles.z + 90) * laserSpeed;
        }
    }

    //Converts radians and degrees to vectors. https://answers.unity.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html
    Vector2 RadiansToVector(float radians)
    {
        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
    }

    Vector2 DegreesToVector(float degrees)
    {
        return RadiansToVector(degrees * Mathf.Deg2Rad);
    }
}
