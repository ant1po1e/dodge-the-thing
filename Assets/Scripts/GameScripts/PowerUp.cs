using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class PowerUp : MonoBehaviour
{
    #region Singleton
    public static PowerUp Instance { get; set; }

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

    public BoxCollider2D playerCollider;

    public float slowness = 2.5f;

    // float currentTime = 0f;
    // float startingTime = 3f;

    public bool isScoreMultiplier;
    public bool isSpeedUp;

    public GameObject slownessUI;
    public GameObject invisibleUI;
    public GameObject scoreMultiplierUI;
    public GameObject speedUpUI;

    // public TMP_Text text;

    void Start()
    {
        playerCollider = gameObject.GetComponent<BoxCollider2D>();

        slownessUI.SetActive(true);
        invisibleUI.SetActive(true);

        isScoreMultiplier = false;
        isSpeedUp = false;

        // currentTime = startingTime;
    }

    void Update()
    {
        // currentTime -= 1 * Time.deltaTime;
    }

    public void StartSlowness()
    {
        StartCoroutine(Slowness());
    }

    public void StartInvisible()
    {
        StartCoroutine(Invisible());
    }

    public void StartScoreMultiplier()
    {
        StartCoroutine(ScoreMultiplier());
    }

    public void StartSpeedUp()
    {
        StartCoroutine(SpeedUp());
    }

    IEnumerator Slowness()
    {
        slownessUI.SetActive(false);
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;

        yield return new WaitForSeconds(15f);

        slownessUI.SetActive(true);
    }

    IEnumerator Invisible()
    {
        invisibleUI.SetActive(false);
        playerCollider.enabled = false;

        yield return new WaitForSeconds(5f);

        playerCollider.enabled = true;

        yield return new WaitForSeconds(30f);

        invisibleUI.SetActive(true);
    }

    IEnumerator ScoreMultiplier()
    {
        scoreMultiplierUI.SetActive(false);
        isScoreMultiplier = true;

        yield return new WaitForSeconds(5f);

        isScoreMultiplier = false;

        yield return new WaitForSeconds(60f);

        scoreMultiplierUI.SetActive(true);
    }

    IEnumerator SpeedUp()
    {
        speedUpUI.SetActive(false);
        isSpeedUp = true;

        yield return new WaitForSeconds(5f);

        isSpeedUp = false;

        yield return new WaitForSeconds(30f);

        speedUpUI.SetActive(true);
    }
}

