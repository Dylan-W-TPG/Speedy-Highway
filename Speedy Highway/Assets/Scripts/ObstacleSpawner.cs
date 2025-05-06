using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Variables
    [SerializeField] private float obstacleSpawnIntervalTime = 1f; // Spawn obstacles on a set interval
    private float initSpawnIntervalTime; // Initial Spawning Interval Time
    [SerializeField] private float obstacleSpawnTimeReductionRate = 1f; // Scale the spawn time
    
    [SerializeField] private GameObject[] obstacles; // List of obstacles

    private PlayerCar car; // Car Object

    private float randomXPos; // Random X Pos
    private Vector3 randomPos; // Random X Pos for a vector
    private float delayTimer; // Delay timer of spawning
    
    // Start is called before the first frame update
    void Start()
    {
        // Get component of Car
        car = GameObject.Find("PlayerCar").GetComponent<PlayerCar>();

        // Set delay timer from interval time
        delayTimer = obstacleSpawnIntervalTime;

        // Set initial variable of interval time
        initSpawnIntervalTime = obstacleSpawnIntervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if game is not over
        if (!GameManager.instance.HasCrashed)
        {
            // Spawn obstacle if delay timer reaches zero
            if (delayTimer <= 0f) SpawnObstacle();
            else delayTimer -= Time.deltaTime;

            // Scale spawn time based on car's current speed
            obstacleSpawnIntervalTime = initSpawnIntervalTime * (car.InitSpeed / car.MainSpeed) / obstacleSpawnTimeReductionRate;
        }
    }

    // Spawn the obstacle in front off-screen
    private void SpawnObstacle()
    {
        // In this if-else statement, check if number of road lanes are even or odd, and randomise the X Pos as such
        if (car.RoadLanes % 2 != 0) randomXPos = car.LaneWidth * Random.Range((-car.RoadLanes / 2), (car.RoadLanes / 2 + 1));
        else randomXPos = car.LaneWidth * Random.Range((-car.RoadLanes / 2), car.RoadLanes / 2) + car.LaneWidth / 2f;

        // Set the Vector Pos based on the X Pos
        randomPos = new Vector3(randomXPos, this.transform.position.y, this.transform.position.z);

        // Spawn a randomised obstacle on the position where the spawner is, with the randomised X Pos
        GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], randomPos, Quaternion.identity);

        // Reset Delay Time
        delayTimer = obstacleSpawnIntervalTime;
    }
}
