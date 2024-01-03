using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    #region Singleton
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public int score = 0;
    int highscore = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void AddPoint()
    {
        if (PowerUp.Instance.isScoreMultiplier == false)
        {
            score += 1;
        }
        else if (PowerUp.Instance.isScoreMultiplier == true)
        {
            score += 3;
        }

        scoreText.text = "Score: " + score.ToString();
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("highscore", 0);
    }

    private void OnTriggerEnter2D()
    {
        if (PauseMenu.instance.isFail != true)
        {
            AddPoint();
        }
    }
}
