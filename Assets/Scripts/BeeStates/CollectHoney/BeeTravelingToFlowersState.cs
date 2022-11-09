using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTravelingToFlowersState : BeeBaseState
{
    private IWorkplace workplace;
    private Vector3 destination;
    private WorkerBee workerBee;

    public override void EnterState(BeeStateManager stateManager)
    {
        Debug.Log("traveling to flowers rn!");
        workplace = stateManager.WorkerBeeComponent.CurrentWorkplace;
        destination = workplace.WorkLocation;
        stateManager.WorkerBeeComponent.Move(destination);
        workerBee = stateManager.WorkerBeeComponent;
        // get the position of clicked flowers
        // set agent destination to clicked flowers
    }

    public override void UpdateState(BeeStateManager stateManager)
    {
        if(stateManager.WorkerBeeComponent.DistanceToDestination() <= 2.0f)
        {
            stateManager.SwitchState(stateManager.collectHoneyState);
        }

        stateManager.ProcessClick();

        /*
         * if reached flower destination / in collision with working range
         *      -change state to BeeCollectingHoneyState
         */

        // if selected and right clicked on another workplace
        //      - change state to corresponding state for that job

        // if selected and left clicked on terrain: change state to not working state
    }
}
