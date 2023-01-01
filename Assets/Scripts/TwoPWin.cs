using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TwoPWin : MonoBehaviour
{
    public int player;

    UIDocument document;
    Label score;
    Button playAgainButton;
    Button mainMenuButton;
    Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        document = GetComponent<UIDocument>();
        score = document.rootVisualElement.Q<Label>("Score");
        playAgainButton = document.rootVisualElement.Q<Button>("PlayAgain");
        mainMenuButton = document.rootVisualElement.Q<Button>("MainMenu");
        quitButton = document.rootVisualElement.Q<Button>("Quit");

        playAgainButton.RegisterCallback<ClickEvent>(PlayAgain);
        mainMenuButton.RegisterCallback<ClickEvent>(MainMenu);
        quitButton.RegisterCallback<ClickEvent>(Quit);

        if (player == 1)
        {
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
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
