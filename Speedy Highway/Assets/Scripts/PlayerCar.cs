using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] private float mainSpeed = 25f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private int roadLanes = 5;

    private DriverInput actions;
    private InputAction steerLeft;
    private InputAction steerRight;

    public int laneNo;
    
    private float xPos;
    private float laneWidth;

    void Awake()
    {
        actions = new DriverInput();
        steerLeft = actions.Driving.SteerLeft;
        steerLeft.started += SteeringLeft;
        steerRight = actions.Driving.SteerRight;
        steerRight.started += SteeringRight;
    }

    void OnEnable()
    {
        steerLeft.Enable();
        steerRight.Enable();
    }

    void OnDisable()
    {
        steerLeft.Disable();
        steerRight.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        laneNo = roadLanes / 2;
        laneWidth = GameObject.Find("Road").transform.lossyScale.x / (float) roadLanes;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.position += Vector3.forward * mainSpeed * Time.deltaTime;
        xPos = (laneNo - 2) * laneWidth;
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        mainSpeed += acceleration * Time.deltaTime;
    }

    void SteeringLeft(InputAction.CallbackContext context)
    {
        if (laneNo > 0) laneNo--;
    }

    void SteeringRight(InputAction.CallbackContext context)
    {
        if (laneNo < roadLanes - 1) laneNo++;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 7) Destroy(this.gameObject);
    }
}
