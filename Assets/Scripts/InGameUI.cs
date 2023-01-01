using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameUI : MonoBehaviour
{
    public GameObject player;
    public GameObject end;
    Player playerScript;
    public UIDocument document;
    Label score;
    Label time;
    VisualElement powerupBar;
    List<GameObject> lastPowerups = new List<GameObject>();
    ProgressBar progress;

    private bool isDirty;
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
        score = document.rootVisualElement.Q<Label>("Score");
        time = document.rootVisualElement.Q<Label>("Time");
        powerupBar = document.rootVisualElement.Q<VisualElement>("PowerupBar");
        progress = document.rootVisualElement.Q<ProgressBar>("Progress");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = $"Score: {playerScript.Score:0}";
        time.text = $"Time: {Mathf.Floor(playerScript.TimeRemaining / 60):0}:{Mathf.Floor(playerScript.TimeRemaining % 60):00}";
        progress.value = Mathf.Clamp(player.transform.position.x / end.transform.position.x, 0, 1);
        if (IsDirty)
        {
            lastPowerups = playerScript.CurrentPowerups;
            UpdatePowerupBar();
        }
    }

    public void UpdatePowerupBar()
    {
        powerupBar.Clear();

        foreach (GameObject powerup in lastPowerups)
        {
            Image icon = new Image();
            icon.sprite = powerup.GetComponent<PowerupEffect>().Sprite;
            icon.style.height = new Length(64.0f, LengthUnit.Pixel);
            icon.style.width = new Length(64.0f, LengthUnit.Pixel);
            powerupBar.Add(icon);
        }

        IsDirty = false;
    }
}
