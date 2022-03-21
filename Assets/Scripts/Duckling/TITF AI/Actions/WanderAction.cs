using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(menuName = "DucklingAI/Actions/Wander")]

public class WanderAction : DucklingAction
{
    public override void Act(DucklingStateController controller)
    {
        Wander(controller);
    }

    public void Wander(DucklingStateController controller)
    {
        if (controller.strollPointSet)
        {
            controller.transform.LookAt(controller.strollPoint);

            controller.agent.SetDestination(controller.strollPoint * controller.ducklingStats.speed * Time.deltaTime);
            


        }
        else
        {
            controller.strollPoint = new Vector3(controller.transform.position.x + Random.Range(controller.ducklingStats.minStrollDistance, controller.ducklingStats.maxStrollDistance), controller.transform.position.y, controller.transform.position.z + Random.Range(controller.ducklingStats.minStrollDistance, controller.ducklingStats.maxStrollDistance));
            controller.strollPointSet = true;
        }

        if (Vector3.Distance(controller.transform.position, controller.strollPoint) <= 0.5f)
        {
            controller.strollPointSet = false;
        }
    }
}
