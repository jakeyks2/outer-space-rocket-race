using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Tracks the player's score
    private int score;

    public int Score
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

    // Start is called before the first frame update
    void Start()
    {
        TimeRemaining = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeRemaining -= Time.deltaTime;
    }
}
