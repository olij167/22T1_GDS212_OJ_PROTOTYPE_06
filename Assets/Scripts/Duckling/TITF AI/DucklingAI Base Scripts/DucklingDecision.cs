using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DucklingDecision : ScriptableObject
{
    public abstract bool Decide(DucklingStateController controller);
}
