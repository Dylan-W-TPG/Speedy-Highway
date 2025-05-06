using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Singleton Instance
    public static UIManager instance;

    private GameObject scoreText; // Text of Distance Travelled

    // Debug Variables for FPS
    private TextMeshProUGUI debugFPSText;
    private int avgFPS;
    private WaitForSecondsRealtime countDelay = new WaitForSecondsRealtime(0.25f);

    // UI Object of Game Over
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
        // Set variables to designated objects based on name
        scoreText = GameObject.Find("Canvas/Distance");
        debugFPSText = GameObject.Find("Canvas/DebugFPS").GetComponent<TextMeshProUGUI>();
        gameOverScreen = GameObject.Find("Canvas/GameOver");
        if (gameOverScreen != null) gameOverScreen.SetActive(false);
    }

    void Update()
    {
        // Update and display Distance Travelled and FPS Counter (if it exists)
        if (scoreText != null) scoreText.GetComponent<TextMeshProUGUI>().text = "Distance: " + GameManager.instance.Distance + " m";
        if (debugFPSText != null) StartCoroutine(FPSCounter());
    }

    // Process and update the FPS, before displaying it in counter text
    IEnumerator FPSCounter()
    {
        yield return countDelay; // Delay based on seconds

        // Show and update FPS if allowed
        if (GameManager.instance.ShowFPSCounter)
        {
            debugFPSText.gameObject.SetActive(true);
            avgFPS = (int) (1f / Time.unscaledDeltaTime);
            debugFPSText.text = "FPS: " + avgFPS;
        }
        else debugFPSText.gameObject.SetActive(false);
    }

    // Display Game Over screen
    public void GameOver()
    {
        gameOverScreen.transform.Find("Panel/DistanceValue").GetComponent<TextMeshProUGUI>().text = GameManager.instance.Distance + " m";
        if (gameOverScreen != null) gameOverScreen.SetActive(true);
    }

    // Restart the scene
    public void SceneRestart()
    {
        GameManager.instance.SceneLoad(SceneManager.GetActiveScene().name);
    }

    // Load the scene
    public void SceneLoad(String name)
    {
        GameManager.instance.SceneLoad(name);
    }

    // Exit the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
