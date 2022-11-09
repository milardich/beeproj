using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTravelingToNexusState : BeeBaseState
{
    public override void EnterState(BeeStateManager bee)
    {
        Debug.Log("traveling to NEXUS rn!");

        // get location of the closest nexus
        // set agent destination to that location
    }

    public override void UpdateState(BeeStateManager bee)
    {
        /*
         * if reached nexus destination / in collision with working range
         *      -change state to BeeUnloadingHoneyState
         */

        // if selected and right clicked on another workplace
        //      - change state to corresponding state for that job

        // if selected and left clicked on terrain: change state to not working state
    }
}
