using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    private PlayerCar car;

    private float randomXPos;
    private Vector3 randomPos;
    private float delayTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("PlayerCar").GetComponent<PlayerCar>();
        delayTimer = GameManager.instance.ObstacleSpawnIntervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.HasCrashed)
        {
            if (delayTimer <= 0f) SpawnObstacle();
            else delayTimer -= Time.deltaTime;
        }
    }

    private void SpawnObstacle()
    {
        if (car.RoadLanes % 2 != 0) randomXPos = car.LaneWidth * Random.Range((-car.RoadLanes / 2), (car.RoadLanes / 2 + 1));
        else randomXPos = car.LaneWidth * Random.Range((-car.RoadLanes / 2), car.RoadLanes / 2) + car.LaneWidth / 2f;

        randomPos = new Vector3(randomXPos, this.transform.position.y, this.transform.position.z);

        GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], randomPos, Quaternion.identity);

        delayTimer = GameManager.instance.ObstacleSpawnIntervalTime;
    }
}
