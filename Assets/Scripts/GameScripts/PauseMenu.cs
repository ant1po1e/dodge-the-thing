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
        InitializeUI();
    }

    void InitializeUI()
    {
        SetPanelActive(pausePanel, false);
        SetPanelActive(failPanel, false);
        SetPanelActive(pauseButton, true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isFail)
        {
            TogglePauseState();
        }
    }

    void TogglePauseState()
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

    public void ResumeGame()
    {
        PlayButtonClickSound();
        SetPanelActive(pauseButton, true);
        SetPanelActive(pausePanel, false);
        SetPanelActive(countUI, true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        PlayButtonClickSound();
        SetPanelActive(pauseButton, false);
        SetPanelActive(pausePanel, true);
        SetPanelActive(countUI, false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void RestartGame()
    {
        PlayButtonClickSound();
        Time.timeScale = 1f;
        SetPanelActive(failPanel, false);
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

    void SetPanelActive(GameObject panel, bool isActive)
    {
        if (panel != null)
        {
            panel.SetActive(isActive);
        }
    }
}
