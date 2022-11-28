using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    public string fireKey;
    public GameObject laserPrefab;
    public float laserSpeed;
    public float laserCooldown;
    public AudioSource audioSource;
    public AudioClip laserAudio;

    private float timeUntilNextLaser = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextLaser -= Time.deltaTime;

        if (Input.GetButtonDown(fireKey) && timeUntilNextLaser <= 0)
        {
            audioSource.PlayOneShot(laserAudio);
            GameObject laserInstance = Instantiate(laserPrefab, transform.position, transform.rotation);
            laserInstance.GetComponent<LaserScript>().velocity = DegreesToVector(transform.rotation.eulerAngles.z + 90) * laserSpeed;
            laserInstance.GetComponent<LaserScript>().owningPlayerScript = gameObject.GetComponent<Player>();
            timeUntilNextLaser = laserCooldown;
        }
    }

    //Converts radians and degrees to vectors. Adapted from https://answers.unity.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html
    Vector2 RadiansToVector(float radians)
    {
        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
    }

    Vector2 DegreesToVector(float degrees)
    {
        return RadiansToVector(degrees * Mathf.Deg2Rad);
    }
}
