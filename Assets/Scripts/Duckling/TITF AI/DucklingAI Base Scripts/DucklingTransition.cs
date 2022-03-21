using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DucklingTransition
{
    public DucklingDecision decision;
    public DucklingState trueState, falseState;
}
