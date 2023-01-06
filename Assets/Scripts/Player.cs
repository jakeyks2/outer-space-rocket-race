using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //The ShipCollision script on this player. Set so its variables can be accessed
    ShipCollision collision;

    //Tracks the powerups the player has
    private List<GameObject> currentPowerups = new List<GameObject>();
    public List<GameObject> CurrentPowerups
    {
        get
        {
            return currentPowerups;
        }
        set
        {
            currentPowerups = value;
        }
    }

    public float scoreLossPerSecond;

    //Tracks the player's score
    private float score;

    public float Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    //Allows the starting time to be set within Unity
    public float startTime;

    //Tracks the player's time remaining
    private float timeRemaining;

    public float TimeRemaining
    {
        get
        {
            return timeRemaining;
        }
        set
        {
            timeRemaining = value;
        }
    }

    //The speed at which the timer should decrease
    private float timerSpeed;

    public float TimerSpeed
    {
        get
        {
            return timerSpeed;
        }
        set
        {
            timerSpeed = value;
        }
    }

    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        collision = GetComponent<ShipCollision>();
        //Set sthe starting score so that it will reach 0 at the same time as the timer reaches 0
        Score = startTime * scoreLossPerSecond;
        TimeRemaining = startTime;
        //Sets the timer to decrease at 1 second per second
        TimerSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Reduces the score based on the timer
        Score -= Time.deltaTime * scoreLossPerSecond * TimerSpeed;
        //Updates the timer
        TimeRemaining -= Time.deltaTime * TimerSpeed;
        //When the player runs out of time
        if (TimeRemaining <= 0)
        {
            if (collision.isSinglePlayer)
            {
                //Creates the death particles
                Instantiate(collision.deathParticle, transform.position, Quaternion.identity);
                //Sets the player as being dead
                collision.Dead = true;
                //Sets the time until the game ends based on the length of the death particle effect
                collision.DeathTime = collision.deathParticle.main.duration;
                //Hides the player's sprite
                GetComponent<SpriteRenderer>().enabled = false;
                //Stops the player moving or turning
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }

            else
            {
                //Updates the other player's score in the game manager
                if (collision.playerNumber == 1)
                {
                    GameManager.playerTwoScore = collision.otherPlayer.Score;
                }
                if (collision.playerNumber == 2)
                {
                    GameManager.playerOneScore = collision.otherPlayer.Score;
                }
                //Loads the game over scene
                SceneManager.LoadScene(collision.sceneToLoadOnTwoPlayerDeath);
            }
        }
    }
}
