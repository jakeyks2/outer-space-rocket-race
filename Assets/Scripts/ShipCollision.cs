using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollision : MonoBehaviour
{
    public GameObject ui;
    public bool isSinglePlayer;

    //Called when the ship enters a trigger collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the ship collided into an obstacle such as an asteroid
        if (collision.tag == "Obstacle")
        {
            if (isSinglePlayer)
            {
                SceneManager.LoadScene("GameOver1P");
            }
        }

        if (collision.tag == "Powerup")
        {
            gameObject.GetComponent<Player>().CurrentPowerups.Add(collision.gameObject.GetComponent<Powerup>().Pickup(gameObject));
            ui.GetComponent<InGameUI>().IsDirty = true;
        }

        if (collision.tag == "Win")
        {
            if (isSinglePlayer)
            {
                GameManager.playerOneScore = gameObject.GetComponent<Player>().Score;
                SceneManager.LoadScene("YouWin1P");
            }
        }
    }
}
