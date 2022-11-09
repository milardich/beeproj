using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeStateManager : MonoBehaviour
{
    private BeeBaseState currentState;

    // Collect honey states
    public BeeTravelingToFlowersState travelToFlowerState = new BeeTravelingToFlowersState();
    public BeeCollectingHoneyState collectHoneyState = new BeeCollectingHoneyState();
    public BeeTravelingToNexusState travelToNexusState = new BeeTravelingToNexusState();
    public BeeUnloadingHoneyState unloadHoneyState = new BeeUnloadingHoneyState();
    public BeeNotWorkingState notWorkingState = new BeeNotWorkingState();

    // Fix building states
    // ...

    // Build structure states
    // ...

    // Some other states
    // ...

    public WorkerBee WorkerBeeComponent;


    public NavMeshAgent Agent { get => this.GetComponent<NavMeshAgent>(); }

    void Start()
    {
        currentState = notWorkingState;
        currentState.EnterState(this);
        WorkerBeeComponent = this.GetComponent<WorkerBee>();
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
