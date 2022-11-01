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
    public bool IsAvailable { get; private set; }

    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
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

    #region Worker
    public int WorkPerformance { get => this.workPerformance; }

    public IWorkplace CurrentWorkplace()
    {
        return this.currentWorkplace;
    }

    public void Work(IWorkplace workPlace)
    {
        IsAvailable = false;
        Debug.Log($"Bee [{this.name}] is now working at [{workPlace.Name}]!");
        this.currentWorkplace = workPlace;
        currentWorkplace.AddWorker(this);    
        workPlace.ProcessWork();
    }

    public void StopWorking()
    {
        IsAvailable = true;
        Debug.Log($"Bee [{this.name}] stopped working!");
        StopMoving();
        this.currentWorkplace = null;
        currentWorkplace.RemoveWorker(this);
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
