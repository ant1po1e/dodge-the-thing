using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float slowness = 10f;

    public void GameOver()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        PlayFailSound();
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(2f / slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayFailSound()
    {
        SoundManager.instance.PlayAudio(SoundManager.instance.gameOver);
    }
}
