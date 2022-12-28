using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Stores the player. Set in the Editor
    public GameObject player;

    public float yOFfset;

    // Update is called once per frame
    void Update()
    {
        //Sets the position of the camera to the player's position. Makes the camera follow the player
        transform.position = new Vector3(Mathf.Max(player.transform.position.x, 0), yOFfset, -10);
    }
}
