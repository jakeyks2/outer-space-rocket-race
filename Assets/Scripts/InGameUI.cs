using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameUI : MonoBehaviour
{
    //The player whose UI this is
    public GameObject player;
    //The end of the track
    public GameObject end;
    Player playerScript;
    //InGameUIVisualTree1 or InGameUIVisualTreeP2
    public UIDocument document;
    //The labels that display the player's current score and remaining time
    Label score;
    Label time;
    //The visual element that contains the icons for each of the player's current powerups
    VisualElement powerupBar;
    //Keeps track of the powerups that were found on the previous update
    List<GameObject> lastPowerups = new List<GameObject>();
    //The progress bar that tracks the player's progress through the level
    ProgressBar progress;

    //Tracks if the UI needs to be updated
    private bool isDirty;
    //A property for isDirty
    public bool IsDirty
    {
        get
        {
            return isDirty;
        }
        set
        {
            isDirty = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        //Finds the UI element in the document based on their name
        score = document.rootVisualElement.Q<Label>("Score");
        time = document.rootVisualElement.Q<Label>("Time");
        powerupBar = document.rootVisualElement.Q<VisualElement>("PowerupBar");
        progress = document.rootVisualElement.Q<ProgressBar>("Progress");
    }

    // Update is called once per frame
    void Update()
    {
        //Displays the score in the format "Score: 600"
        score.text = $"Score: {playerScript.Score:0}";
        //Displays the player's remaining time in the format "Time: 1:00"
        time.text = $"Time: {Mathf.Floor(playerScript.TimeRemaining / 60):0}:{Mathf.Floor(playerScript.TimeRemaining % 60):00}";
        //Updates the progress bar based on the progress through the level the player has made
        progress.value = Mathf.Clamp(player.transform.position.x / end.transform.position.x, 0, 1);
        if (IsDirty)
        {
            //Updates the lastPowerups variable
            lastPowerups = playerScript.CurrentPowerups;
            UpdatePowerupBar();
        }
    }

    public void UpdatePowerupBar()
    {
        //Removes all visual elements from the powerup bar
        powerupBar.Clear();

        //Iterates through the player's powerups
        foreach (GameObject powerup in lastPowerups)
        {
            //Creates an empty Image
            Image icon = new Image();
            //Sets the sprite to the powerup's sprite
            icon.sprite = powerup.GetComponent<PowerupEffect>().Sprite;
            //Sets the height and width to 64 pixels
            icon.style.height = new Length(64.0f, LengthUnit.Pixel);
            icon.style.width = new Length(64.0f, LengthUnit.Pixel);
            powerupBar.Add(icon);
        }

        //Marks the powerup bar as having been updated
        IsDirty = false;
    }
}
