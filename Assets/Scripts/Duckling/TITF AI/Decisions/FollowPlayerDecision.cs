using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DucklingAI/Decisions/FollowPlayer")]

public class FollowPlayerDecision : DucklingDecision
{
    public override bool Decide(DucklingStateController controller)
    {
        bool followPlayer = SeePlayer(controller);
        return followPlayer;
    }

    private bool SeePlayer(DucklingStateController controller)
    {
            if (controller.detection.detectedObjects.Contains(controller.player))
            {
                return true;
            }
            else return false;
    }
}
