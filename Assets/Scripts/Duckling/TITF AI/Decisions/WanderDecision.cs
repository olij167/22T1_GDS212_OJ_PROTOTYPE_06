using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DucklingAI/Decisions/Wander")]

public class WanderDecision : DucklingDecision
{
    public override bool Decide(DucklingStateController controller)
    {
        bool dontSeePlayer = DontSeePlayer(controller);
        return dontSeePlayer;
    }

    private bool DontSeePlayer(DucklingStateController controller)
    {
        if (!controller.detection.detectedObjects.Contains(controller.player))
        {
            return true;
        }
        else return false;
    }
}
