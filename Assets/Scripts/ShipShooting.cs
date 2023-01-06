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

    //Whether the player should automatically shoot
    private bool autoShoot;

    public bool AutoShoot
    {
        get
        {
            return autoShoot;
        }
        set
        {
            autoShoot = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AutoShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the cooldown timer
        timeUntilNextLaser -= Time.deltaTime;

        //If the cooldown has finished and the player presses the fire button
        if ((Input.GetButtonDown(fireKey) || AutoShoot) && timeUntilNextLaser <= 0)
        {
            //Plays a laser sound
            audioSource.PlayOneShot(laserAudio);
            //Creates a copy of the laser prefab
            GameObject laserInstance = Instantiate(laserPrefab, transform.position, transform.rotation);
            //Sets the laser velocity
            laserInstance.GetComponent<LaserScript>().velocity = DegreesToVector(transform.rotation.eulerAngles.z + 90) * laserSpeed;
            laserInstance.GetComponent<LaserScript>().owningPlayerScript = gameObject.GetComponent<Player>();
            //Resets the cooldown
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
