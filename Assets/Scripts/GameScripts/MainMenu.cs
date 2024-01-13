using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject levelPanel;
    public GameObject creditPanel;
    public GameObject helpPanel;

    void Start()
    {
        InitializePanels();
    }

    void InitializePanels()
    {
        SetPanelActive(levelPanel, false);
        SetPanelActive(menuPanel, true);
        SetPanelActive(creditPanel, false);
        SetPanelActive(helpPanel, false);
    }

    void SetPanelActive(GameObject panel, bool isActive)
    {
        if (panel != null)
        {
            panel.SetActive(isActive);
        }
    }

    public void PlayGame()
    {
        PlayButtonClickSound();
        SetPanelActive(levelPanel, true);
        SetPanelActive(menuPanel, false);
    }

    public void LoadLevel(string levelName)
    {
        PlayButtonClickSound();
        SceneManager.LoadScene(levelName);
    }

    public void PlayClosed()
    {
        PlayButtonClickSound();
        SetPanelActive(levelPanel, false);
        SetPanelActive(menuPanel, true);
    }

    public void QuitGame()
    {
        PlayButtonClickSound();
        Application.Quit();
    }

    public void ResetButton()
    {
        PlayButtonClickSound();
        ScoreManager.instance.ResetHighscore();
    }

    public void CreditOpen()
    {
        PlayButtonClickSound();
        SetPanelActive(creditPanel, true);
    }

    public void CreditClosed()
    {
        PlayButtonClickSound();
        SetPanelActive(creditPanel, false);
    }

    public void HelpOpen()
    {
        PlayButtonClickSound();
        SetPanelActive(helpPanel, true);
        SetPanelActive(menuPanel, false);
        SetPanelActive(creditPanel, false);
    }

    public void HelpClosed()
    {
        PlayButtonClickSound();
        SetPanelActive(helpPanel, false);
        SetPanelActive(menuPanel, true);
        SetPanelActive(creditPanel, true);
    }

    public void PlayButtonClickSound()
    {
        SoundManager.instance.PlayAudio(SoundManager.instance.buttonUI);
    }
}
