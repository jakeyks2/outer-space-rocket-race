using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class YouWin : MonoBehaviour
{
    //YouWin1PVisualTree
    UIDocument document;
    //The buttons on the win screen
    Button retryButton;
    Button mainMenuButton;
    Button quitButton;
    //The label that displays the player's score
    Label scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        document = GetComponent<UIDocument>();
        //Finds the elements based on their names
        retryButton = document.rootVisualElement.Q<Button>("RetryButton");
        mainMenuButton = document.rootVisualElement.Q<Button>("MainMenuButton");
        quitButton = document.rootVisualElement.Q<Button>("QuitButton");
        scoreLabel = document.rootVisualElement.Q<Label>("Score");

        //Adds functions to run when buttons are clicked
        retryButton.RegisterCallback<ClickEvent>(Retry);
        mainMenuButton.RegisterCallback<ClickEvent>(MainMenu);
        quitButton.RegisterCallback<ClickEvent>(Quit);
        //Sets the score to text in the format "Score: 600"
        scoreLabel.text = $"Score: {GameManager.playerOneScore:0}";
    }

    void Retry(ClickEvent evt)
    {
        SceneManager.LoadScene("1PlayerScene");
    }

    void MainMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Quit(ClickEvent evt)
    {
        //Exits the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
