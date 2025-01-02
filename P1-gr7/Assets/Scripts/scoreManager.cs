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


 

    void Awake()
    {
        Debug.Log(score);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keeps the ScoreManager between scenes
        }
        else
        {
            Destroy(gameObject);  // Destroys duplicate ScoreManager instances
        }
    }

    public void addScore(int amount)
    {
        score += amount;
        updateScoreText();
    }

    private void updateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Coins: " + score.ToString();
        }
    }
       

    public void ShowWinScreen()
    {

        if (winScreen != null)
        {

            winScreen.SetActive(true); // Activate the Win Screen
        }
        Time.timeScale = 0; // Pause the game (optional)
    }

    public void RestartGame()
 {
    score = 0; // Reset score
    updateScoreText(); // Update the UI
    Time.timeScale = 1; // Resume time
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
public void LoadStartScreen()
{
    // Replace "StartScreenSceneName" with the name of your start screen scene
    SceneManager.LoadScene("StartScreen");
}
}
