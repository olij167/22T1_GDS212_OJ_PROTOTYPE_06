using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DucklingObjectDetection : MonoBehaviour
{
    DucklingStateController controller;

    public List<Transform> detectedObjects;

    int interestingLayers;
    void Start()
    {
        interestingLayers = 1 << LayerMask.NameToLayer("InterestingStuff");
        controller = GetComponent<DucklingStateController>();
        detectedObjects = new List<Transform>();
        //DetectObjects(detectedObjects);
    }

    private void Update()
    {
        DetectObjects(detectedObjects);
    }

    public List<Transform> DetectObjects(List<Transform> objectsAroundAI)
    {
        List<Collider> hitColliders = new List<Collider>(Physics.OverlapSphere(transform.position, controller.ducklingStats.lookRadius, interestingLayers));

        foreach (var hitCollider in hitColliders)
        {
            if (!objectsAroundAI.Contains(hitCollider.transform))
            objectsAroundAI.Add(hitCollider.transform);
        }
        //RaycastHit hit;
        //if (Physics.SphereCast(controller.eyes.position, controller.ducklingStats.lookRadius, controller.transform.forward, out hit, controller.ducklingStats.lookRadius) && !detectedObjects.Contains(hit.transform))
        //{
        //    Debug.DrawLine(controller.transform.position, hit.point, Color.magenta);

        //    objectsAroundAI.Add(hit.transform);
        //}

        if (objectsAroundAI.Count > hitColliders.Count)
        {
            for (int i = 0; i < objectsAroundAI.Count; i++)
            {
                //if (objectsAroundAI[i] != Physics.SphereCast(controller.eyes.position, controller.ducklingStats.lookRadius, controller.transform.forward, out hit, controller.ducklingStats.lookRadius))
                if (!hitColliders.Contains(objectsAroundAI[i].GetComponent<Collider>()))
                {
                    objectsAroundAI.Remove(detectedObjects[i]);
                }
            }
        }

        return objectsAroundAI;
    }
}
