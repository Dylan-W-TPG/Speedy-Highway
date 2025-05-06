using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton Instance
    public static GameManager instance;

    // Distance Travelled
    private float distance;
    public float Distance
    {
        get
        {
            return distance;
        }
        set
        {
            distance = value;
        }
    }

    // Delay Time after crashing before showing UI
    [SerializeField] private float crashUIDelayTime = 3f;

    // If Car has Crashed
    private bool hasCrashed;
    public bool HasCrashed
    {
        get
        {
            return hasCrashed;
        }
    }

    // DEBUG MODE
    [Header("Debug Mode")]
    [SerializeField] private bool limitFPS; // Cap the maximum FPS
    [SerializeField] private int FPS = 30; // Set Game FPS
    [SerializeField] private bool showFPSCounter; // Show FPS Counter at the corner of the screen
    public bool ShowFPSCounter
    {
        get
        {
            return showFPSCounter;
        }
    }

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object across scenes
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Begin Game Initiation
        Initiate();
        
        // Limit FPS instead of depending on vSyncing
        if (limitFPS)
        {
            QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
            Application.targetFrameRate = FPS;
        }

        // If this game is built on Android, set the intended refresh rate as FPS
        if (Application.platform == RuntimePlatform.Android)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = (int) Screen.currentResolution.refreshRateRatio.value;
        }
    }

    // Reset game state to normal
    private void Initiate()
    {
        hasCrashed = false;
    }

    // Request a Game Over when car has crashed
    public void CarCrash()
    {
        hasCrashed = true;
        StartCoroutine(GameOver());
    }

    // Delay with a set number of seconds before showing GameOver UI
    IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(crashUIDelayTime);
        UIManager.instance.GameOver();
    }

    // Load scene based on name in string
    public void SceneLoad(String name)
    {
        Initiate();
        SceneManager.LoadScene(name);
    }
}
