using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreRuler : MonoBehaviour
{
    public static ScoreRuler instance;

    [SerializeField]
    private TextMeshProUGUI scoreText, finalScoreText, maxScoreText, finMaxScore;

    public int score;
    
    void Awake()
    {
        score = 0;
        if (instance == null)
        {
            instance = this;
        }
        SetHighScore();
    }

    public void SetHighScore() {
        maxScoreText.text = PlayerPrefs.GetInt("maxscore").ToString();
        finMaxScore.text = PlayerPrefs.GetInt("maxscore").ToString();
    }

    public void SetScore()
    {
        score++;
        scoreText.text = score.ToString();
        finalScoreText.text = score.ToString();
    }
}
