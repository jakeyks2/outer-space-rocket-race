using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameUI : MonoBehaviour
{
    public GameObject player;
    Player playerScript;
    public UIDocument document;
    Label score;
    Label time;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        score = (Label)document.rootVisualElement.Q("Score");
        time = (Label)document.rootVisualElement.Q("Time");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = $"Score: {playerScript.Score}";
        time.text = $"Time: {Mathf.Floor(playerScript.TimeRemaining / 60):0}:{Mathf.Floor(playerScript.TimeRemaining % 60):00}";
    }
}
