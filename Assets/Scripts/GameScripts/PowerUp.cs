using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Animations;

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

    public int maxPowerUpStack = 3;

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

    IEnumerator Invisible()
    {
        ToggleUI(invisibleUI, false);
        ToggleCollider(false);
        AnimationController.instance.PlayCameraAnimation("IsInvisible", true);
        AnimationController.instance.PlayPlayerAnimation("IsPlayerInvisible", true);

        yield return new WaitForSeconds(5.5f);

        ToggleCollider(true);
        AnimationController.instance.PlayCameraAnimation("IsInvisible", false);
        AnimationController.instance.PlayPlayerAnimation("IsPlayerInvisible", false);

        yield return new WaitForSeconds(30f);

        ToggleUI(invisibleUI, true);
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
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        AnimationController.instance.PlayCameraAnimation("IsSlowness", true);

        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;
        AnimationController.instance.PlayCameraAnimation("IsSlowness", false);

        yield return new WaitForSeconds(15f);

        ToggleUI(slownessUI, true);
    }

    IEnumerator ScoreMultiplier()
    {
        ToggleUI(scoreMultiplierUI, false);
        isScoreMultiplier = true;
        AnimationController.instance.PlayCameraAnimation("IsScoreMultiplier", true);

        yield return new WaitForSeconds(5f);

        isScoreMultiplier = false;
        AnimationController.instance.PlayCameraAnimation("IsScoreMultiplier", false);

        yield return new WaitForSeconds(60f);

        ToggleUI(scoreMultiplierUI, true);
    }

    IEnumerator SpeedUp()
    {
        ToggleUI(speedUpUI, false);
        isSpeedUp = true;
        AnimationController.instance.PlayCameraAnimation("IsSpeedUp", true);

        yield return new WaitForSeconds(5f);

        isSpeedUp = false;
        AnimationController.instance.PlayCameraAnimation("IsSpeedUp", false);

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
}
