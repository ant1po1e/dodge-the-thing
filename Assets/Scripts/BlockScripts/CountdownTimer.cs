using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float startingTime = 3f;

    public GameObject scoreSpawner;
    public GameObject blockSpawner;
    public GameObject GUI;
    public GameObject countText;
    public TMP_Text text;

    private float currentTime;

    void Start()
    {
        InitializeTimer();
        SetInitialUIState();
    }

    void InitializeTimer()
    {
        currentTime = startingTime;
    }

    void SetInitialUIState()
    {
        ToggleGameObject(scoreSpawner, false);
        ToggleGameObject(blockSpawner, false);
        ToggleGameObject(countText, true);
        ToggleGameObject(GUI, false);
    }

    void Update()
    {
        UpdateTimer();
        UpdateUIText();

        if (currentTime <= 0)
        {
            SetGamePlayUIState();
        }
    }

    void UpdateTimer()
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(0f, currentTime);
    }

    void UpdateUIText()
    {
        text.text = currentTime.ToString("0");
    }

    void SetGamePlayUIState()
    {
        ToggleGameObject(scoreSpawner, true);
        ToggleGameObject(blockSpawner, true);
        ToggleGameObject(countText, false);
        ToggleGameObject(GUI, true);
    }

    void ToggleGameObject(GameObject gameObject, bool isActive)
    {
        if (gameObject != null)
        {
            gameObject.SetActive(isActive);
        }
    }
}
