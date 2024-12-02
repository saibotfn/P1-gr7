using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    public int score = 0;
    public TMP_Text scoreText;


    void Awake()
    {
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
       public GameObject winScreen; // Reference to the Win Screen Canvas

    public void ShowWinScreen()
    {
        winScreen.SetActive(true); // Activate the Win Screen
        Time.timeScale = 0; // Pause the game (optional)
    }

    public void RestartGame()
 {
    score = 0; // Reset score
    updateScoreText(); // Update the UI
    Time.timeScale = 1; // Resume time
    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); // Reload scene
}
}
