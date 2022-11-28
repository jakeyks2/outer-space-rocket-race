using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    public GameObject ui;

    //Called when the ship enters a trigger collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the ship collided into an obstacle such as an asteroid
        if (collision.tag == "Obstacle")
        {
            //Temporary way to end the game
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        if (collision.tag == "Powerup")
        {
            gameObject.GetComponent<Player>().CurrentPowerups.Add(collision.gameObject.GetComponent<Powerup>().Pickup(gameObject));
            ui.GetComponent<InGameUI>().IsDirty = true;
        }
    }
}
