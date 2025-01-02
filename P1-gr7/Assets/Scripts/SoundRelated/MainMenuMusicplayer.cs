using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource musicSource; //Holds audio source component

    public AudioClip MainMenuMusic;

    private static MainMenuMusicPlayer instance;

    int lastMenuSceneIndex = (int)ScenesManager.Scene.WorldScene; //used for checking if menu music should stop, start or just keep playing

    int currentSceneIndex;
    int previousSceneIndex;

    // Makes the gameobject persist between scenes
    private void Awake()
    {
        // Ensure there's only one instance of AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make the GameObject persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void StartMenuMusic() //Starts menu music
    {
        musicSource.clip = MainMenuMusic;
        musicSource.Play();
    }

    void Start()
    {
        StartMenuMusic();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += WhenSceneIsloaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= WhenSceneIsloaded;
    }

    private void WhenSceneIsloaded(Scene scene, LoadSceneMode mode)
    {

        previousSceneIndex = currentSceneIndex; //Sets the previousSceneIndex to currentSceneIndex (before currentSceneIndex is changed, meaning it is actually the index of the previous scene)
        currentSceneIndex = scene.buildIndex; //Sets the currentSceneIndex to the index of the current scene

        // Will exit function if scene index was and is <=2, meaning main menu music will keep playing
        if (previousSceneIndex <= lastMenuSceneIndex && currentSceneIndex <= lastMenuSceneIndex)
        {
            return;
        }
        //Start the menu music if scene is changed from the game to the menu
        if (previousSceneIndex > lastMenuSceneIndex && currentSceneIndex <= lastMenuSceneIndex)
        {
            StartMenuMusic();
        }
        //Stop the menu music if scene is changed from the menu to the game
        if (previousSceneIndex <= lastMenuSceneIndex && currentSceneIndex > lastMenuSceneIndex)
        {
            musicSource.Stop();
        }
    }
}