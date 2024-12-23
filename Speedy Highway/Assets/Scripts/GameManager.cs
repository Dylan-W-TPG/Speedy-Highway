using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayerCar car;

    private float distance;
    public float Distance
    {
        get
        {
            return distance;
        }
    }

    // DEBUG MODE
    [Header("Debug Mode")]
    [SerializeField] private bool limitFPS;
    [SerializeField] private int FPS = 30;
    [SerializeField] private bool showFPSCounter;
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
        Initiate();
        
        if (limitFPS)
        {
            QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
            Application.targetFrameRate = FPS;
        }
    }

    private void Initiate()
    {
        car = GameObject.Find("PlayerCar").GetComponent<PlayerCar>();
    }

    void Update()
    {
        if (car != null)
        {
            distance = Mathf.Round(car.transform.position.z);
        }
    }
}
