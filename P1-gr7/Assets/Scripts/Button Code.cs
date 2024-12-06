using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSceneLoader : MonoBehaviour
{
    private Button button;

    // Enum to specify which action this button should trigger
    public enum Action
    {
        LoadNewGame,
        LoadNextScene,
        LoadMainMenu
    }

    public Action buttonAction;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        switch (buttonAction)
        {
            case Action.LoadNewGame:
                ScenesManager.Instance.LoadNewGame();
                break;
            case Action.LoadNextScene:
                ScenesManager.Instance.LoadNextScene();
                break;
            case Action.LoadMainMenu:
                ScenesManager.Instance.LoadStartScreen();
                break;
        }
    }
}
