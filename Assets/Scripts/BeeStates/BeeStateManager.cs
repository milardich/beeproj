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

    // TODO: make this cleaner
    public void ProcessClick()
    {
        if (WorkerBeeComponent.IsSelected() &&
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
                    WorkerBeeComponent.StopAllCoroutines();
                    SwitchState(notWorkingState);
                    WorkerBeeComponent.Move(destination);
                    WorkerBeeComponent.transform.GetChild(2).gameObject.SetActive(false);
                }
                else if (hit.transform.tag == "Workplace")
                {
                    WorkerBeeComponent.StopAllCoroutines();
                    SwitchState(notWorkingState);

                    bool isWorkplace = hit.transform.TryGetComponent<IWorkplace>(out IWorkplace workplace);
                    if (isWorkplace)
                    {
                        WorkerBeeComponent.Work(workplace);
                        if (workplace.WorkType == WorkType.CollectHoney)
                        {
                            SwitchState(travelToFlowerState);
                            WorkerBeeComponent.transform.GetChild(2).gameObject.SetActive(true);
                        }
                        else if(workplace.WorkType == WorkType.UnloadHoney)
                        {
                            SwitchState(travelToNexusState);
                            WorkerBeeComponent.transform.GetChild(2).gameObject.SetActive(true);
                        }
                        // else if work type == barracks - SwitchState(travelToBarracks
                        // else if work type == buildStructure - switchState(travelToWorkPlace)
                    }
                }
            }
        }
    }
}
