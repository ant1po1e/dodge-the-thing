using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float slowness =10f;

    public void GameOver()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime =  Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f /slowness);
        
        Time.timeScale = 1f;
        Time.fixedDeltaTime =  Time.fixedDeltaTime * slowness;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
