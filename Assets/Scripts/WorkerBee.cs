using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WorkerBee : Unit, IMoveable, IWorker
{
    //[SerializeField] private Vector3 destination;
    private NavMeshAgent agent;
    [SerializeField] float workPerformance = 100; //%, TODO: read this from config file
    private IWorkplace currentWorkplace;
    private bool isWorking = false;
    [SerializeField] private List<Building> buildableBuildings;

    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    new void Start()
    {
        base.Start();
    }

    public void Move(Vector3 destination)
    {
        this.agent.isStopped = false;
        this.agent.SetDestination(destination);
    }

    public void StopMoving()
    {
        this.agent.SetDestination(this.transform.position);
        this.agent.isStopped = true;
    }

    public float WorkPerformance { get => this.workPerformance; }

    public IWorkplace CurrentWorkplace { get => this.currentWorkplace; }

    public bool IsWorking { get => this.isWorking; set => this.isWorking = value; }

    public bool WorkDone { get; set; }

    public void Work(IWorkplace workPlace)
    {
        Debug.Log($"Bee [{this.name}] is now working at [{workPlace.Name}]!");
        this.currentWorkplace = workPlace;
        currentWorkplace.AddWorker(this);
        workPlace.ProcessWork();
        this.IsWorking = true;
    }

    public void StopWorking()
    {
        this.IsWorking = false;
        Debug.Log($"Bee [{this.name}] stopped working!");
        //StopMoving();
        currentWorkplace.RemoveWorker(this);
        //this.currentWorkplace = null;
    }


    /* Worker bee abilities:
     * 
     * work (collect honey) 
     * repair building
     * build buildings
     * attack
     */
}
