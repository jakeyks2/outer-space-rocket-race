using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPowerup : Powerup
{
    //The explosion particle
    public GameObject particles;

    public override void OnPickup(GameObject player)
    {
        //https://answers.unity.com/questions/8003/how-can-i-know-if-a-gameobject-is-seen-by-a-partic.html
        //Finds the planes that lie on the camera
        Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(player.GetComponent<Player>().mainCamera);
        //Iterates through every object with the Obstacle tag ie asteroid in the game
        foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            //Checks if the camera's planes intersect the current asteroid
            if (GeometryUtility.TestPlanesAABB(cameraPlanes, asteroid.GetComponent<Collider2D>().bounds))
            {
                //Increases the player's score based on the asteroid's health
                player.GetComponent<Player>().Score += 10 * asteroid.GetComponent<Asteroid>().Health;
                //Creates an explosion particle at the asteroid's position
                Instantiate(particles, asteroid.transform.position, Quaternion.identity);
                Destroy(asteroid);
            }
        }
    }
}
