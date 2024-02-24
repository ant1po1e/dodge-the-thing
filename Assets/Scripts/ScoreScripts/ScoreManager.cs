using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    public Animator backgroundAnim;


    #region Singleton
    public static ScoreManager Instance
    { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
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

    void Update()
    {
        if (score >= 25)
        {
            backgroundAnim.SetBool("IsBackgroundChange", true);
        }
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
