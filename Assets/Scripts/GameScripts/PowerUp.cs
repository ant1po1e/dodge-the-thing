using System.Collections;
using UnityEngine;
using TMPro;

public class PowerUp : MonoBehaviour
{
    #region Singleton
    public static PowerUp Instance { get; private set; }

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

    public float slowness = 5f;
    public bool isScoreMultiplier;
    public bool isSpeedUp;

    public GameObject slownessUI;
    public GameObject invisibleUI;
    public GameObject scoreMultiplierUI;
    public GameObject speedUpUI;

    private SpriteRenderer playerRenderer;
    private Color playerColor;

    void Start()
    {
        InitializeComponents();
        InitializeUI();
        ResetPowerUpStatus();
    }

    void Update()
    {
        // Remove unnecessary code or add meaningful comments if needed
    }

    void InitializeComponents()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        playerColor = playerRenderer.color;
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    void InitializeUI()
    {
        slownessUI.SetActive(true);
        invisibleUI.SetActive(true);
    }

    void ResetPowerUpStatus()
    {
        isScoreMultiplier = false;
        isSpeedUp = false;
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
        ToggleUI(slownessUI, false);
        AdjustTimeScale(1f / slowness, 1f / slowness);

        yield return new WaitForSeconds(1f);

        ResetTimeScale();

        yield return new WaitForSeconds(15f);

        ToggleUI(slownessUI, true);
    }

    IEnumerator Invisible()
    {
        ToggleUI(invisibleUI, false);
        ToggleCollider(false);
        AdjustPlayerColor(0.1f);

        yield return new WaitForSeconds(5.5f);

        ToggleCollider(true);
        AdjustPlayerColor(1f);

        yield return new WaitForSeconds(30f);

        ToggleUI(invisibleUI, true);
    }

    IEnumerator ScoreMultiplier()
    {
        ToggleUI(scoreMultiplierUI, false);
        isScoreMultiplier = true;

        yield return new WaitForSeconds(5f);

        isScoreMultiplier = false;

        yield return new WaitForSeconds(60f);

        ToggleUI(scoreMultiplierUI, true);
    }

    IEnumerator SpeedUp()
    {
        ToggleUI(speedUpUI, false);
        isSpeedUp = true;

        yield return new WaitForSeconds(5f);

        isSpeedUp = false;

        yield return new WaitForSeconds(30f);

        ToggleUI(speedUpUI, true);
    }

    void ToggleUI(GameObject uiObject, bool isActive)
    {
        if (uiObject != null)
        {
            uiObject.SetActive(isActive);
        }
    }

    void AdjustTimeScale(float timeScale, float fixedDeltaTime)
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = Time.fixedDeltaTime / timeScale;
    }

    void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }

    void ToggleCollider(bool isEnabled)
    {
        if (playerCollider != null)
        {
            playerCollider.enabled = isEnabled;
        }
    }

    void AdjustPlayerColor(float alpha)
    {
        playerColor.a = alpha;
        playerRenderer.color = playerColor;
    }
}
