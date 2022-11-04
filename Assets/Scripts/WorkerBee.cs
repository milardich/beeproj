using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WorkerBee : Unit, IMoveable, IWorker
{
    //[SerializeField] private Vector3 destination;
    private NavMeshAgent agent;
    [SerializeField] int workPerformance = 100; //%, TODO: read this from config file
    [SerializeField] private IWorkplace currentWorkplace;
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
        this.agent.destination = destination;
    }

    public void StopMoving()
    {
        this.agent.isStopped = true;
    }

    #region IWorker
    public int WorkPerformance { get => this.workPerformance; }

    public IWorkplace CurrentWorkplace{ get => this.currentWorkplace; }

    public bool IsWorking { get => this.isWorking; set => this.isWorking = value; }

    public void Work(IWorkplace workPlace)
    {
        this.IsWorking = true;
        Debug.Log($"Bee [{this.name}] is now working at [{workPlace.Name}]!");
        this.currentWorkplace = workPlace;
        currentWorkplace.AddWorker(this);    
        workPlace.ProcessWork();
    }

    public void StopWorking()
    {
        this.IsWorking = false;
        Debug.Log($"Bee [{this.name}] stopped working!");
        //StopMoving();
        currentWorkplace.RemoveWorker(this);
        //this.currentWorkplace = null;
    }
    #endregion

    

    /* Worker bee abilities:
     * 
     * work (collect honey) 
     * repair building
     * build buildings
     * attack
     */
}
