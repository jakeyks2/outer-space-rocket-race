using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    public UIDocument document;
    Button onePButton;
    Button twoPButton;
    Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        onePButton = document.rootVisualElement.Q<Button>("1PButton");
        twoPButton = document.rootVisualElement.Q<Button>("2PButton");
        quitButton = document.rootVisualElement.Q<Button>("QuitButton");

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
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
