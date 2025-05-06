using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCar : MonoBehaviour
{
    // Variables
    // Car's Speed
    [SerializeField] private float mainSpeed = 25f;
    public float MainSpeed
    {
        get
        {
            return mainSpeed;
        }
    }

    // Car's Initial Speed
    private float initSpeed;
    public float InitSpeed
    {
        get
        {
            return initSpeed;
        }
    }

    [SerializeField] private float acceleration = 0.1f; // Car's Acceleration
    
    // Number of Road Lanes
    [SerializeField] private int roadLanes = 5;
    public int RoadLanes
    {
        get
        {
            return roadLanes;
        }
    }

    [SerializeField] private GameObject brokenVersion; // Broken Version of Car Prefab
    [SerializeField] private float explosionForce = 100f; // Explosion force of Crash
    [SerializeField] private float explosionRadius = 10f; // Explosion radius of Crash
    [SerializeField] private float upwardModifier = 5f; // Additive Upward force of Crash
    [SerializeField] private float forwardModifier = 0.5f; // Additive Forward force of Crash

    private Rigidbody rB; // Rigidbody

    // Driver Input variables
    private DriverInput actions;
    private InputAction steerLeft;
    private InputAction steerRight;
    private InputAction steerTouch;
    private InputAction touchPosition;

    public int laneNo; // Lane Number
    
    private float xPos; // X Position

    // Width of Road Lane
    private float laneWidth;
    public float LaneWidth
    {
        get
        {
            return laneWidth;
        }
    }

    // Assign inputs to variables
    void Awake()
    {
        actions = new DriverInput();
        steerLeft = actions.Driving.SteerLeft;
        steerLeft.started += SteeringLeft;
        steerRight = actions.Driving.SteerRight;
        steerRight.started += SteeringRight;
        steerTouch = actions.Driving.SteerTouch;
        steerTouch.started += StartTouch;
        touchPosition = actions.Driving.TouchPosition;
    }

    // Enable controls
    void OnEnable()
    {
        steerLeft.Enable();
        steerRight.Enable();
        steerTouch.Enable();
        touchPosition.Enable();
    }

    // Disable controls
    void OnDisable()
    {
        steerLeft.Disable();
        steerRight.Disable();
        steerTouch.Disable();
        touchPosition.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        laneNo = roadLanes / 2; // Get middle lane number
        laneWidth = GameObject.Find("Road").transform.lossyScale.x / (float) roadLanes; // Get Road Lane Width
        rB = GetComponent<Rigidbody>(); // Get rigidbody
        initSpeed = mainSpeed; // Set intial speed
    }

    // Update is called once per frame
    void Update()
    {
        // Get car's pivot and move car forward every frame
        transform.parent.position += Vector3.forward * mainSpeed * Time.deltaTime;
        
        // Set car X Pos based on lane number and move the car to that spot
        xPos = (laneNo - 2) * laneWidth;
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        
        // Gradually increase speed based on acceleration
        mainSpeed += acceleration * Time.deltaTime;

        // Transfer Distance Travelled to GameManager
        GameManager.instance.Distance = Mathf.Round(transform.position.z);
    }

    // Move car to the left by decrementing lane number (prevent out-of-bounds)
    void SteeringLeft(InputAction.CallbackContext context)
    {
        if (laneNo > 0) laneNo--;
    }

    // Move car to the right by incrementing lane number (prevent out-of-bounds)
    void SteeringRight(InputAction.CallbackContext context)
    {
        if (laneNo < roadLanes - 1) laneNo++;
    }

    // If touching the screen, determine steering based on screen half horizontally
    void StartTouch(InputAction.CallbackContext context)
    {
        if (touchPosition.ReadValue<Vector2>().x <= (float) Screen.width / 2f) SteeringLeft(context);
        else SteeringRight(context);
    }

    // Check if the car collides with an obstacle
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 7)
        {
            // Initiate car crashing
            GameManager.instance.CarCrash();
            
            // Spawn broken version of car to the car's position
            GameObject brokenCar = Instantiate(brokenVersion, this.transform.position, this.transform.rotation);

            // Apply explosive force to all broken parts at its origin
            foreach (Transform carPart in brokenCar.transform)
            {
                carPart.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, rB.position - (Vector3.forward * forwardModifier), explosionRadius, upwardModifier, ForceMode.Impulse);
            }

            // Destroy the intial car
            Destroy(this.gameObject, 0.01f);
        }
    }
}
