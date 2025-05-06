using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    // Destroy any objects with the Obstacle layer
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer == 7) Destroy(col.gameObject);
    }
}
