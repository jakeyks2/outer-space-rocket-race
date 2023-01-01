using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollision : MonoBehaviour
{
    public GameObject ui;
    public bool isSinglePlayer;
    public ParticleSystem deathParticle;
    public string sceneToLoadOnTwoPlayerDeath;
    public int playerNumber;
    public Player otherPlayer;
    bool dead = false;
    float deathTime = 0.0f;

    void Update()
    {
        deathTime -= Time.deltaTime;
        if (deathTime <= 0.0f && dead)
        {
            SceneManager.LoadScene("GameOver1P");
        }
    }

    //Called when the ship enters a trigger collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the ship collided into an obstacle such as an asteroid
        if (collision.tag == "Obstacle")
        {
            if (isSinglePlayer)
            {
                Instantiate(deathParticle, transform.position, Quaternion.identity);
                dead = true;
                deathTime = deathParticle.main.duration;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }

            else
            {
                if (playerNumber == 1)
                {
                    GameManager.playerTwoScore = otherPlayer.Score;
                }
                if (playerNumber == 2)
                {
                    GameManager.playerOneScore = otherPlayer.Score;
                }
                SceneManager.LoadScene(sceneToLoadOnTwoPlayerDeath);
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
            else
            {
                if (playerNumber == 1)
                {
                    GameManager.playerOneScore = gameObject.GetComponent<Player>().Score;
                    SceneManager.LoadScene("Player1Wins");
                }
                if (playerNumber == 2)
                {
                    GameManager.playerTwoScore = gameObject.GetComponent<Player>().Score;
                    SceneManager.LoadScene("Player2Wins");
                }
            }
        }
    }
}
