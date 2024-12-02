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
}
