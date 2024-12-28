using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private GameObject scoreText;

    private TextMeshProUGUI debugFPSText;
    private int avgFPS;
    private WaitForSecondsRealtime countDelay = new WaitForSecondsRealtime(0.25f);

    private GameObject gameOverScreen;

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
        scoreText = GameObject.Find("Canvas/Distance");
        debugFPSText = GameObject.Find("Canvas/DebugFPS").GetComponent<TextMeshProUGUI>();
        gameOverScreen = GameObject.Find("Canvas/GameOver");
        if (gameOverScreen != null) gameOverScreen.SetActive(false);
    }

    void Update()
    {
        if (scoreText != null) scoreText.GetComponent<TextMeshProUGUI>().text = "Distance: " + GameManager.instance.Distance + " m";
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

    public void GameOver()
    {
        gameOverScreen.transform.Find("Panel/DistanceValue").GetComponent<TextMeshProUGUI>().text = GameManager.instance.Distance + " m";
        if (gameOverScreen != null) gameOverScreen.SetActive(true);
    }

    public void SceneRestart()
    {
        GameManager.instance.SceneLoad(SceneManager.GetActiveScene().name);
    }

    public void SceneLoad(String name)
    {
        GameManager.instance.SceneLoad(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
