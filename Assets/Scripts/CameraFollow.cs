using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Stores the player. Set in Start
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the player variable to a GameObject with the tag Player, which will be the Ship object
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the position of the camera to the player's position. Makes the camera follow the player
        transform.position = new Vector3(player.transform.position.x, 0, -10);
    }
}
