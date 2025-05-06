using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevelHandler : MonoBehaviour
{
    // Variables
    private PlayerCar car; // Car Object
    private float carZPos; // Get position of how far the car has diven
    
    [SerializeField] private GameObject section; // Section of the level
    private GameObject[] sectionPool; // Storage Pool of sections

    private float sectionLength; // Length of the road section

    public float sectionNo; // Section number
    
    // Start is called before the first frame update
    void Start()
    {
        // Get component of PlayerCar
        car = GameObject.Find("PlayerCar").GetComponent<PlayerCar>();
        
        // Get the length and initial number of the road section
        sectionLength = section.transform.GetChild(0).lossyScale.y;
        sectionNo = 1;
        
        // Create a pool and assign the first two sections
        sectionPool = new GameObject[2];
        for (int i = 0; i < sectionPool.Length; i++)
        {
            // Create a new road section and assign it at the end of the road
            sectionPool[i] = Instantiate(section);
            sectionPool[i].transform.position = new Vector3(0f, 0f, i * sectionLength);
        }

        // Hide that section for now
        section.SetActive(false);
    }

    void Update()
    {
        // Check if the game is not over and the car is still usable
        if (!GameManager.instance.HasCrashed && car != null)
        {
            // Update the variable based on car's Z Pos
            carZPos = car.transform.position.z;

            // Check if the Z Pos has reached halfway of the road section
            if (carZPos >= sectionNo * sectionLength)
            {
                // Increment the section number and move the first road section in pool in front of the second
                sectionPool[0].transform.position = new Vector3(0f, 0f, ++sectionNo * sectionLength);

                // Swap the sections in pool
                GameObject temp = sectionPool[0];
                sectionPool[0] = sectionPool[1];
                sectionPool[1] = temp;
            }
        }
    }
}
