using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    public UIDocument document;
    public string retryScene;
    Button retryButton;
    Button mainMenuButton;
    Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        retryButton = document.rootVisualElement.Q<Button>("RetryButton");
        mainMenuButton = document.rootVisualElement.Q<Button>("MainMenuButton");
        quitButton = document.rootVisualElement.Q<Button>("QuitButton");

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
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
