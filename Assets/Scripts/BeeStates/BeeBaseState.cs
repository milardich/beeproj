using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BeeBaseState
{
    public abstract void EnterState(BeeStateManager state);
    public abstract void UpdateState(BeeStateManager state);
}
