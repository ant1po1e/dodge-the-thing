using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject levelPanel;

    void Start()
    {
        levelPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void PlayGame()
    {
        levelPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void ToLevelOne()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void ToLevelTwo()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void ToLevelThree()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void ToLevelFour()
    {
        SceneManager.LoadScene("Level_4");
    }

    public void ToLevelFive()
    {
        SceneManager.LoadScene("Level_5");
    }

    public void PlayClosed()
    {
        levelPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
