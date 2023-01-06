using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    //MainMenuVisualTree
    public UIDocument document;
    //The buttons on the main menu
    Button onePButton;
    Button twoPButton;
    Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the buttons in the document based on their names
        onePButton = document.rootVisualElement.Q<Button>("1PButton");
        twoPButton = document.rootVisualElement.Q<Button>("2PButton");
        quitButton = document.rootVisualElement.Q<Button>("QuitButton");

        //Adds functions for when the buttons are clicked
        onePButton.RegisterCallback<ClickEvent>(StartOnePlayer);
        twoPButton.RegisterCallback<ClickEvent>(StartTwoPlayer);
        quitButton.RegisterCallback<ClickEvent>(Quit);
    }

    void StartOnePlayer(ClickEvent evt)
    {
        SceneManager.LoadScene("1PlayerScene");
    }

    void StartTwoPlayer(ClickEvent evt)
    {
        SceneManager.LoadScene("2PlayerScene");
    }

    void Quit(ClickEvent evt)
    {
#if UNITY_EDITOR
        // If in editor, stop playing
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //If standalone application, close app
        Application.Quit();
#endif
    }
}
