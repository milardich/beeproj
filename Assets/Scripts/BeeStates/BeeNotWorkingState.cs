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
        WorkerBee workerBee = bee.WorkerBeeComponent;

        if(bee.WorkerBeeComponent.IsSelected() &&
            Input.GetMouseButtonDown(InputManager.Instance.mouseSecondary))
        {
            Vector3 destination = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Terrain")
                {
                    destination = hit.point;
                    workerBee.Move(destination);
                }
                else if(hit.transform.tag == "Workplace")
                {
                    bool isWorkplace = hit.transform.TryGetComponent<IWorkplace>(out IWorkplace workplace);
                    if (isWorkplace)
                    {
                        bee.WorkerBeeComponent.Work(workplace);
                        if(workplace.WorkType == WorkType.CollectHoney)
                        {
                            bee.SwitchState(bee.travelToFlowerState);
                        }
                    }
                }
            }
        }

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
