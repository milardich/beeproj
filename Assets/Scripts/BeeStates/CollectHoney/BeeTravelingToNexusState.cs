using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTravelingToNexusState : BeeBaseState
{
    private Vector3 _closestNexusLocation;
    public override void EnterState(BeeStateManager bee)
    {
        Debug.Log("traveling to NEXUS rn!");
        _closestNexusLocation = GetClosestNexusLocation();
        bee.WorkerBeeComponent.Move(_closestNexusLocation);
        // get location of the closest nexus
        // set agent destination to that location
    }

    public override void UpdateState(BeeStateManager bee)
    {
        if (bee.WorkerBeeComponent.DistanceToDestination() <= 2.0f)
        {
            bee.SwitchState(bee.unloadHoneyState);
        }
        /*
         * if reached nexus destination / in collision with working range
         *      -change state to BeeUnloadingHoneyState
         */

        // if selected and right clicked on another workplace
        //      - change state to corresponding state for that job

        // if selected and left clicked on terrain: change state to not working state
    }

    private Vector3 GetClosestNexusLocation()
    {
        // TODO: cast ray to each nexus and return closest one
        return new Vector3(-21.5992851f, 1.12047315f, -25.9468842f);
    }
}
