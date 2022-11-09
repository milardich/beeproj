using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class BeeUnloadingHoneyState : BeeBaseState
{
    private WorkerBee workerBee;

    public override void EnterState(BeeStateManager bee)
    {
        Debug.Log("Unloading honey rn!");
        workerBee = bee.WorkerBeeComponent;
        bee.StartCoroutine(workerBee.UnloadHoney());

        // set timer for unloading time
        // TODO: play unloading honey animation 
    }

    public override void UpdateState(BeeStateManager bee)
    {
        bee.ProcessClick();

        /*
         * update bee honey capacity over time 
         *      -subtract honey from bee bucket and add that honey to global honey value
         * 
         * if honey bucket <= 0: honey bucket value = 0
         *      - change state to BeeTravelingToFLowersState
         *   
         */

        // if selected and right clicked on another workplace
        //      - change state to corresponding state for that job


        // if bee is selected and right clicked on terrain - switch states
    }
}
