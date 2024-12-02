using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public static ScenesManager Instance;


    public int CurrentSceneIndex { get; private set; }

    private void Awake()
    {
        Instance = this;
        UpdateCurrentSceneIndex();
    }

    public enum Scene
    {
        StartScreen,
        MainMenu,
        SettingScene,

    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.StartScreen.ToString());

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadSettingScene()
    {
        SceneManager.LoadScene(Scene.SettingScene.ToString());
    }

    private void UpdateCurrentSceneIndex()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
