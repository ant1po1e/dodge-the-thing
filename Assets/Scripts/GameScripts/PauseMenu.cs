using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public bool isFail = false;
    public GameObject pausePanel;
    public GameObject failPanel;
    public GameObject countUI;
    public GameObject pauseButton;

    #region Singleton
    public static PauseMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    void Start()
    {
        pausePanel.SetActive(false);
        failPanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isFail == false)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        PlayButtonClickSound();
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        countUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        PlayButtonClickSound();
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        countUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void RestartGame()
    {
        PlayButtonClickSound();
        Time.timeScale = 1f;
        failPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isFail = false;
    }

    public void MainMenu()
    {
        PlayButtonClickSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayButtonClickSound()
    {
        SoundManager.instance.PlayAudio(SoundManager.instance.buttonUI);
    }
}
