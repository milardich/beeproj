using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCollectingHoneyState : BeeBaseState
{
    WorkerBee workerBee;
    HoneyBucket bucket;

    public override void EnterState(BeeStateManager bee)
    {
        Debug.Log("Collectin honey rn!");
        workerBee = bee.WorkerBeeComponent;
        bucket = bee.WorkerBeeComponent.honeyBucket;
        bee.StartCoroutine(CollectHoney(bee));
        // start timer for collecting honey
        // TODO: play animation for
    }

    public override void UpdateState(BeeStateManager bee)
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

    private IEnumerator CollectHoney(BeeStateManager bee)
    {
        yield return new WaitForSeconds(5.0f);
        bucket.FillUp(5);
        Debug.Log($"Honey collected ({bucket.CurrentCapacity}) delivering to nexus rn!");
        bee.SwitchState(bee.travelToNexusState);
    }
}
