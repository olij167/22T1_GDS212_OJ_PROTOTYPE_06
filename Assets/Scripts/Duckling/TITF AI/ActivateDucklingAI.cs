using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDucklingAI : MonoBehaviour
{
    DucklingStateController controller;
    void Start()
    {
        controller = GetComponent<DucklingStateController>();
        Vector3 startingStrollPoint = new Vector3(controller.transform.position.x + Random.Range(controller.ducklingStats.minStrollDistance, controller.ducklingStats.maxStrollDistance), controller.transform.position.y, controller.transform.position.z + Random.Range(controller.ducklingStats.minStrollDistance, controller.ducklingStats.maxStrollDistance));

        controller.strollPointSet = true;

        controller.SetupAI(true, startingStrollPoint);
    }
}
