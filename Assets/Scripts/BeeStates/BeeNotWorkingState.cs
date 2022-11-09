using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeNotWorkingState : BeeBaseState
{
    public override void EnterState(BeeStateManager bee)
    {
        Debug.Log("Not working now!");
        // stop moving etc
    }

    public override void UpdateState(BeeStateManager bee)
    {
        bee.ProcessClick();

        /*
         * if bee is selected and if right clicked on place of work
         *      - change state to corresponding state for that job
         */
    }

    void SendBeeToWork(WorkerBee workerBee, RaycastHit hit)
    {
        IWorkplace workplace;
        IWorker worker;
        IMoveable moveable;

        bool isWorkplace = hit.transform.TryGetComponent<IWorkplace>(out workplace);
        if (isWorkplace)
        {

            bool isWorker = workerBee.TryGetComponent<IWorker>(out worker);
            bool canMove = workerBee.TryGetComponent<IMoveable>(out moveable);

            if (isWorker && canMove)
            {
                moveable.Move(workplace.WorkLocation);
                worker.Work(workplace);
            }
            
        }
    }
}
