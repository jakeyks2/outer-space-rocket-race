using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class YouWin : MonoBehaviour
{
    UIDocument document;
    Button retryButton;
    Button mainMenuButton;
    Button quitButton;
    Label scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        document = GetComponent<UIDocument>();
        retryButton = document.rootVisualElement.Q<Button>("RetryButton");
        mainMenuButton = document.rootVisualElement.Q<Button>("MainMenuButton");
        quitButton = document.rootVisualElement.Q<Button>("QuitButton");
        scoreLabel = document.rootVisualElement.Q<Label>("Score");

        retryButton.RegisterCallback<ClickEvent>(Retry);
        mainMenuButton.RegisterCallback<ClickEvent>(MainMenu);
        quitButton.RegisterCallback<ClickEvent>(Quit);
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
