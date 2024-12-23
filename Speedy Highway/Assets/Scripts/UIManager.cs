using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private TextMeshProUGUI scoreText;

    private TextMeshProUGUI debugFPSText;
    private int avgFPS;
    private WaitForSecondsRealtime countDelay = new WaitForSecondsRealtime(0.25f);

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Ensure only one instance of UIManager exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        scoreText = GameObject.Find("Canvas/Distance").GetComponent<TextMeshProUGUI>();
        debugFPSText = GameObject.Find("Canvas/DebugFPS").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = "Distance: " + GameManager.instance.Distance + " m";
        if (debugFPSText != null) StartCoroutine(FPSCounter());
    }

    IEnumerator FPSCounter()
    {
        yield return countDelay;

        if (GameManager.instance.ShowFPSCounter)
        {
            debugFPSText.gameObject.SetActive(true);
            avgFPS = (int) (1f / Time.unscaledDeltaTime);
            debugFPSText.text = "FPS: " + avgFPS;
        }
        else debugFPSText.gameObject.SetActive(false);
    }
}
