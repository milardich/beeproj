using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WorkerBee : Unit, IMoveable, IWorker
{
    private NavMeshAgent agent;
    [SerializeField] float workPerformance = 100; //%, TODO: read this from config file
    private bool isWorking = false;
    [SerializeField] private List<Building> buildableBuildings;

    public Vector3 CurrentDestination;
    public HoneyBucket honeyBucket;
    private float unloadTime = 2.0f;
    public BeeStateManager beeStateManager;

    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        this.AddComponent<HoneyBucket>();
        honeyBucket = this.GetComponent<HoneyBucket>();

    }

    new void Start()
    {
        base.Start();
        beeStateManager = this.GetComponent<BeeStateManager>();
    }

    public void Move(Vector3 destination)
    {
        this.agent.isStopped = false;
        this.agent.SetDestination(destination);
        CurrentDestination = destination;
    }

    public void StopMoving()
    {
        this.agent.SetDestination(this.transform.position);
        this.agent.isStopped = true;
    }

    public float WorkPerformance { get => this.workPerformance; }

    public IWorkplace CurrentWorkplace { get; set; }

    public bool IsWorking { get => this.isWorking; set => this.isWorking = value; }

    public bool WorkDone { get; set; }

    public void Work(IWorkplace workPlace)
    {
        Debug.Log($"Bee [{this.name}] is now working at [{workPlace.Name}]!");
        CurrentWorkplace = workPlace;
        CurrentWorkplace.AddWorker(this);
        workPlace.ProcessWork();
        this.IsWorking = true;
    }

    public void StopWorking()
    {
        this.IsWorking = false;
        Debug.Log($"Bee [{this.name}] stopped working!");
        //StopMoving();
        CurrentWorkplace.RemoveWorker(this);
        //this.currentWorkplace = null;
    }

    public float DistanceToDestination()
    {
        return this.agent.remainingDistance;
    }


    // TOOD: 
    public IWorkplace GetClosestNexus()
    {
        IWorkplace nexus = null;
        return nexus;
    }

    // TODO:
    public IWorkplace GetClosestFlowers()
    {
        IWorkplace flowers = null;
        return flowers;
    }

    public IEnumerator CollectHoney()
    {
        yield return new WaitForSeconds(5.0f);
        honeyBucket.FillUp(5);
        Debug.Log($"Honey collected ({honeyBucket.CurrentCapacity}) delivering to nexus rn!");
        beeStateManager.SwitchState(beeStateManager.travelToNexusState);
    }

    public IEnumerator UnloadHoney()
    {
        yield return new WaitForSeconds(unloadTime);
        honeyBucket.Empty(5);
        Debug.Log($"Honey unloaded ({honeyBucket.CurrentCapacity})!");
        //this.Work(GetClosestWorkplace(WorkType.CollectHoney));
        beeStateManager.SwitchState(beeStateManager.travelToFlowerState);
    }

    // TODO:
    public IWorkplace GetClosestWorkplace(WorkType type)
    {
        IWorkplace closestWorkplace = null;
        List<IWorkplace> workplaces = UnitManager.Instance.AllWorkplaces;
        List<IWorkplace> allFlowers = UnitManager.Instance.AllFlowers;
        List<IWorkplace> allNexuses = UnitManager.Instance.AllNexuses;

        float minimumDistance;
        if(type == WorkType.CollectHoney) 
        {
            minimumDistance = Vector3.Distance(this.transform.position, allFlowers[0].WorkLocation);
            foreach (IWorkplace flowersWorkplace in allFlowers)
            {
                float distance = Vector3.Distance(this.transform.position, flowersWorkplace.WorkLocation);
                if (distance <= minimumDistance)
                {
                    closestWorkplace = flowersWorkplace;
                }
            }
        }

        if(type == WorkType.UnloadHoney)
        {
            minimumDistance = Vector3.Distance(this.transform.position, allNexuses[0].WorkLocation);
            foreach (IWorkplace nexusWorkplace in allNexuses)
            {
                float distance = Vector3.Distance(this.transform.position, nexusWorkplace.WorkLocation);
                if (distance <= minimumDistance)
                {
                    closestWorkplace = nexusWorkplace;
                }
            }
        }

        return closestWorkplace;
    }

    /* Worker bee abilities:
     * 
     * work (collect honey) 
     * repair building
     * build buildings
     * attack
     */
}
