using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private float obstacleSpawnIntervalTime = 1f;
    public float ObstacleSpawnIntervalTime
    {
        get
        {
            return obstacleSpawnIntervalTime;
        }
    }
    private float initSpawnIntervalTime;
    [SerializeField] private float obstacleSpawnTimeReductionRate = 1f;

    private PlayerCar car;
    private float initSpeed;

    private float distance;
    public float Distance
    {
        get
        {
            return distance;
        }
    }

    [SerializeField] private float crashUIDelayTime = 3f;
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
        initSpawnIntervalTime = obstacleSpawnIntervalTime;
        
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
        initSpeed = car.MainSpeed;
        obstacleSpawnIntervalTime = initSpawnIntervalTime;
        hasCrashed = false;
    }

    void Update()
    {
        if (car != null && !hasCrashed)
        {
            distance = Mathf.Round(car.transform.position.z);
            obstacleSpawnIntervalTime = initSpawnIntervalTime * (initSpeed / car.MainSpeed) / obstacleSpawnTimeReductionRate;
        }
    }

    public void CarCrash()
    {
        hasCrashed = true;
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(crashUIDelayTime);
        Debug.Log("Game Over.");
    }
}
