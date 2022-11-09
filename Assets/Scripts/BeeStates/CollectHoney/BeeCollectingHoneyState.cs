using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCollectingHoneyState : BeeBaseState
{
    public override void EnterState(BeeStateManager state)
    {
        Debug.Log("Collectin honey rn!");

        // start timer for collecting honey
        // TODO: play animation for
    }

    public override void UpdateState(BeeStateManager state)
    {
        /*
         * update bee honey capacity over time
         * 
         * if honey bucket >= max capacity: honey bucket value = max capacity
         *      - change state to BeeTravelingToNexusState
         *   
         */

        // if selected and right clicked on another workplace
        //      - change state to corresponding state for that job

        // if bee is selected and right clicked on terrain - switch states
    }
}
