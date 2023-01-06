using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollision : MonoBehaviour
{
    //The player's ui
    public GameObject ui;
    //Whether the game is being played in 1 player
    public bool isSinglePlayer;
    //The explosion particle that will be played
    public ParticleSystem deathParticle;
    //What scene to load when this player dies in 2 player
    public string sceneToLoadOnTwoPlayerDeath;
    //If the player is player 1 or 2
    public int playerNumber;
    //The other player in the game
    public Player otherPlayer;
    bool dead = false;
    public bool Dead
    {
        get
        {
            return dead;
        }
        set
        {
            dead = value;
        }
    }
    //The time until game over is displayed
    float deathTime = 0.0f;
    public float DeathTime
    {
        get
        {
            return deathTime;
        }
        set
        {
            deathTime = value;
        }
    }

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
                //Cerates the death particle
                Instantiate(deathParticle, transform.position, Quaternion.identity);
                Dead = true;
                //Sets the death time equal to the time for the death particle to play
                DeathTime = deathParticle.main.duration;
                //Hides the player's sprite
                GetComponent<SpriteRenderer>().enabled = false;
                //Stops the player moving
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }

            else
            {
                //Updates the other player's score in the game manager
                if (playerNumber == 1)
                {
                    GameManager.playerTwoScore = otherPlayer.Score;
                }
                if (playerNumber == 2)
                {
                    GameManager.playerOneScore = otherPlayer.Score;
                }
                //Loads the game over scene
                SceneManager.LoadScene(sceneToLoadOnTwoPlayerDeath);
            }
        }

        if (collision.tag == "Powerup")
        {
            //Adds the powerup to the player's list and runs its pickup function
            gameObject.GetComponent<Player>().CurrentPowerups.Add(collision.gameObject.GetComponent<Powerup>().Pickup(gameObject));
            //Marks the player's UI as dirty
            ui.GetComponent<InGameUI>().IsDirty = true;
        }

        if (collision.tag == "Win")
        {
            //Updates the player's score and sends them to the win screen
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
