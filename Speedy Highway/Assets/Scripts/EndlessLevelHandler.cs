using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevelHandler : MonoBehaviour
{
    private PlayerCar car;
    private float carZPos;
    
    [SerializeField] private GameObject section;
    private GameObject[] sectionPool;

    private float sectionLength;

    public float sectionNo;
    
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("PlayerCar").GetComponent<PlayerCar>();
        
        sectionLength = section.transform.GetChild(0).lossyScale.y;
        sectionNo = 1;
        
        sectionPool = new GameObject[2];
        for (int i = 0; i < sectionPool.Length; i++)
        {
            sectionPool[i] = Instantiate(section);
            sectionPool[i].transform.position = new Vector3(0f, 0f, i * sectionLength);
        }

        section.SetActive(false);
    }

    void Update()
    {
        if (!GameManager.instance.HasCrashed && car != null)
        {
            carZPos = car.transform.position.z;
            if (carZPos >= sectionNo * sectionLength)
            {
                sectionPool[0].transform.position = new Vector3(0f, 0f, ++sectionNo * sectionLength);

                GameObject temp = sectionPool[0];
                sectionPool[0] = sectionPool[1];
                sectionPool[1] = temp;
            }
        }
    }
}
