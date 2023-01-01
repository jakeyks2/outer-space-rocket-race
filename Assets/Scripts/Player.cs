using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        Score = startTime * scoreLossPerSecond;
        TimeRemaining = startTime;
        TimerSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Score -= Time.deltaTime * scoreLossPerSecond * TimerSpeed;
        TimeRemaining -= Time.deltaTime * TimerSpeed;
    }
}
