using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPowerup : Powerup
{
    public GameObject particles;

    public override void OnPickup(GameObject player)
    {
        //https://answers.unity.com/questions/8003/how-can-i-know-if-a-gameobject-is-seen-by-a-partic.html
        Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(player.GetComponent<Player>().mainCamera);
        foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            if (GeometryUtility.TestPlanesAABB(cameraPlanes, asteroid.GetComponent<Collider2D>().bounds))
            {
                player.GetComponent<Player>().Score += 10 * asteroid.GetComponent<Asteroid>().Health;
                Instantiate(particles, asteroid.transform.position, Quaternion.identity);
                Destroy(asteroid);
            }
        }
    }
}
