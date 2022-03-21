using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DucklingAction : ScriptableObject
{
    public abstract void Act(DucklingStateController controller);
}
