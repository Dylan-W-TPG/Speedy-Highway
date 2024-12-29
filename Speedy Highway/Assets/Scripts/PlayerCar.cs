using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] private float mainSpeed = 25f;
    public float MainSpeed
    {
        get
        {
            return mainSpeed;
        }
    }
    private float initSpeed;
    public float InitSpeed
    {
        get
        {
            return initSpeed;
        }
    }
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private int roadLanes = 5;
    public int RoadLanes
    {
        get
        {
            return roadLanes;
        }
    }

    [SerializeField] private GameObject brokenVersion;
    [SerializeField] private float explosionForce = 100f;
    [SerializeField] private float explosionRadius = 10f;
    [SerializeField] private float upwardModifier = 5f;
    [SerializeField] private float forwardModifier = 0.5f;

    private Rigidbody rB;

    private DriverInput actions;
    private InputAction steerLeft;
    private InputAction steerRight;
    private InputAction steerTouch;
    private InputAction touchPosition;

    public int laneNo;
    
    private float xPos;
    private float laneWidth;
    public float LaneWidth
    {
        get
        {
            return laneWidth;
        }
    }

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

    void OnEnable()
    {
        steerLeft.Enable();
        steerRight.Enable();
        steerTouch.Enable();
        touchPosition.Enable();
    }

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
        laneNo = roadLanes / 2;
        laneWidth = GameObject.Find("Road").transform.lossyScale.x / (float) roadLanes;
        rB = GetComponent<Rigidbody>();
        initSpeed = mainSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.position += Vector3.forward * mainSpeed * Time.deltaTime;
        xPos = (laneNo - 2) * laneWidth;
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        mainSpeed += acceleration * Time.deltaTime;

        GameManager.instance.Distance = Mathf.Round(transform.position.z);
    }

    void SteeringLeft(InputAction.CallbackContext context)
    {
        if (laneNo > 0) laneNo--;
    }

    void SteeringRight(InputAction.CallbackContext context)
    {
        if (laneNo < roadLanes - 1) laneNo++;
    }

    void StartTouch(InputAction.CallbackContext context)
    {
        if (touchPosition.ReadValue<Vector2>().x <= (float) Screen.width / 2f) SteeringLeft(context);
        else SteeringRight(context);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 7)
        {
            GameManager.instance.CarCrash();
            
            GameObject brokenCar = Instantiate(brokenVersion, this.transform.position, this.transform.rotation);
            foreach (Transform carPart in brokenCar.transform)
            {
                carPart.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, rB.position - (Vector3.forward * forwardModifier), explosionRadius, upwardModifier, ForceMode.Impulse);
            }

            Destroy(this.gameObject, 0.01f);
        }
    }
}
