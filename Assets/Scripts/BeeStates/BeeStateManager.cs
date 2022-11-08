using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeStateManager : MonoBehaviour
{
    private BeeBaseState currentState;
    private BeeTravelToFlowersState travelToFlowerState = new BeeTravelToFlowersState();
    private BeeCollectHoneyState collectHoneyState = new BeeCollectHoneyState();
    private BeeTravelToNexusState travelToNexusState = new BeeTravelToNexusState();
    private BeeUnloadHoneyState unloadHoneyState = new BeeUnloadHoneyState();

    void Start()
    {
        currentState = travelToFlowerState;
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BeeBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
