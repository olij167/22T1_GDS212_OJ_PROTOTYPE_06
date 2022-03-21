using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DucklingAI/State")]
public class DucklingState : ScriptableObject
{
    public DucklingAction[] actions;
    public DucklingTransition[] transitions;
    public Color sceneGizmoColor = Color.grey;

    public void UpdateState(DucklingStateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(DucklingStateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(DucklingStateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded)
            {
                controller.TransitionToState(transitions[i].trueState);
            }
            else
            {
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }
}
