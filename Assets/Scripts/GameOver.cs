using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    //The UI document. Will be GameOverVisualTree
    public UIDocument document;
    //The scene to load when retry is clicked
    public string retryScene;
    //The buttons on the menu
    Button retryButton;
    Button mainMenuButton;
    Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the buttons in the document based on their name
        retryButton = document.rootVisualElement.Q<Button>("RetryButton");
        mainMenuButton = document.rootVisualElement.Q<Button>("MainMenuButton");
        quitButton = document.rootVisualElement.Q<Button>("QuitButton");

        //Adds events to the buttons for when they are clicked
        retryButton.RegisterCallback<ClickEvent>(Retry);
        mainMenuButton.RegisterCallback<ClickEvent>(MainMenu);
        quitButton.RegisterCallback<ClickEvent>(Quit);
    }

    void Retry(ClickEvent evt)
    {
        SceneManager.LoadScene(retryScene);
    }

    void MainMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Quit(ClickEvent evt)
    {
#if UNITY_EDITOR
        //If played in editor, stops game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //Closes the program if not played in editor
        Application.Quit();
#endif
    }
}
