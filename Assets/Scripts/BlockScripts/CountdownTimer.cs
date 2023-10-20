using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;

    public GameObject scoreSpawner;
    public GameObject blockSpawner;
    public GameObject GUI;
    public GameObject countText;

    public TMP_Text text;



    void Start()
    {
        currentTime = startingTime;
        scoreSpawner.SetActive(false);
        blockSpawner.SetActive(false);
        countText.SetActive(true);
        GUI.SetActive(false);
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        text.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            scoreSpawner.SetActive(true);
            blockSpawner.SetActive(true);
            countText.SetActive(false);
            GUI.SetActive(true);
            currentTime = 0;
        }
    }
}
