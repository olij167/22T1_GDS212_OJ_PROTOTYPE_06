using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DucklingAI/Actions/FollowPlayer")]
public class DucklingFollowPlayerAction : DucklingAction
{
    public override void Act(DucklingStateController controller)
    {
        FollowPlayer(controller);
    }

    public void FollowPlayer(DucklingStateController controller)
    {
        controller.transform.LookAt(controller.player.position);
        controller.agent.SetDestination(controller.player.position * controller.ducklingStats.speed * Time.deltaTime);
    }
}
