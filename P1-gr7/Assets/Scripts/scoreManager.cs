using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject winScreen; // Reference to the Win Screen Canvas


 

// Awake is called when the script instance is being loaded
void Awake()
{
    // Log the current score to the console for debugging purposes
    Debug.Log(score);
    
    // Check if there is no existing instance of this class
    if (instance == null)
    {
        // Set the current object as the instance
        instance = this;

        // Ensure this object persists across scene changes
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        // If an instance already exists, destroy this duplicate object
        Destroy(gameObject);
    }
}

 // Method to add points to the player's score
public void addScore(int amount)
{
    // Increment the score by the specified amount
    score += amount;
    
    // Update the displayed score text to reflect the new score
    updateScoreText();
}

// Private method to update the visual representation of the score
private void updateScoreText()
{
    // Check if the scoreText UI element is not null to avoid errors
    if (scoreText != null)
    {
        // Update the text of the scoreText UI element to show the current score
        scoreText.text = "Coins: " + score.ToString();
    }
}
       

// Method to display the win screen
public void ShowWinScreen()
{
    // Check if the winScreen object is not null to avoid runtime errors
    if (winScreen != null)
    {
        // Activate the Win Screen UI element
        winScreen.SetActive(true);
    }

    // Pause the game by setting the time scale to 0
    Time.timeScale = 0; // Optional, ensures the game is paused when the win screen is displayed
}

// Method to restart the current game
public void RestartGame()
{
    // Reset the score to 0
    score = 0;

    // Update the score UI to reflect the reset score
    updateScoreText();

    // Resume normal game time
    Time.timeScale = 1;

    // Reload the current scene to restart the game
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

// Method to load the start screen
public void LoadStartScreen()
{
    // Load the scene designated as the start screen
    // Replace "StartScreenSceneName" with the actual name of your start screen scene
    SceneManager.LoadScene("StartScreen");
}
}
