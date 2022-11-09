using System.Collections.Generic;
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

    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        this.AddComponent<HoneyBucket>();
        honeyBucket = this.GetComponent<HoneyBucket>();

    }

    new void Start()
    {
        base.Start();
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

    /* Worker bee abilities:
     * 
     * work (collect honey) 
     * repair building
     * build buildings
     * attack
     */
}
