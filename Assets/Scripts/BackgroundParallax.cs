using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    //Stores the player. Set in the Editor
    public GameObject player;
    public float yOFfset;
    // Update is called once per frame
    void Update()
    {
        //Sets the position of the camera to the player's position with a multiplicative offset. Creates a parallax effect as the player moves
        transform.position = new Vector3(player.transform.position.x * 0.5f, yOFfset, 0);
    }
}
