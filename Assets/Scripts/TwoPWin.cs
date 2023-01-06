using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TwoPWin : MonoBehaviour
{
    //The player number of the winning player
    public int player;

    //The player win UI document
    UIDocument document;
    //The label that will show the winning player's score
    Label score;
    //When clicked, restarts the level
    Button playAgainButton;
    //When clicked, returns to the main menu
    Button mainMenuButton;
    //When clicked, closes the game
    Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the UI document component. Will be Player1Wins or Player2Wins
        document = GetComponent<UIDocument>();
        //Find the elements in the UI document
        score = document.rootVisualElement.Q<Label>("Score");
        playAgainButton = document.rootVisualElement.Q<Button>("PlayAgain");
        mainMenuButton = document.rootVisualElement.Q<Button>("MainMenu");
        quitButton = document.rootVisualElement.Q<Button>("Quit");

        //Assign events on click to buttons
        playAgainButton.RegisterCallback<ClickEvent>(PlayAgain);
        mainMenuButton.RegisterCallback<ClickEvent>(MainMenu);
        quitButton.RegisterCallback<ClickEvent>(Quit);

        //Checks which player won
        if (player == 1)
        {
            //Formats the score eg Score: 600
            score.text = $"Score: {GameManager.playerOneScore:0}";
        }

        if (player == 2)
        {
            score.text = $"Score: {GameManager.playerTwoScore:0}";
        }
    }

    void PlayAgain(ClickEvent evt)
    {
        SceneManager.LoadScene("2PlayerScene");
    }

    void MainMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Quit(ClickEvent evt)
    {
#if UNITY_EDITOR
        //Stops playing the game in editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //Closes the program when not in editor
        Application.Quit();
#endif
    }
}
