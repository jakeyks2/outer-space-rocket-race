using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameUI : MonoBehaviour
{
    public GameObject player;
    Player playerScript;
    public UIDocument document;
    Label score;
    Label time;
    VisualElement powerupBar;
    List<GameObject> lastPowerups = new List<GameObject>();

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
        score = (Label)document.rootVisualElement.Q("Score");
        time = (Label)document.rootVisualElement.Q("Time");
        powerupBar = document.rootVisualElement.Q("PowerupBar");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = $"Score: {playerScript.Score:0}";
        time.text = $"Time: {Mathf.Floor(playerScript.TimeRemaining / 60):0}:{Mathf.Floor(playerScript.TimeRemaining % 60):00}";
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
            powerupBar.Add(icon);
        }

        IsDirty = false;
    }
}
