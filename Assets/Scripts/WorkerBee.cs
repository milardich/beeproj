using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WorkerBee : Unit, IMoveable
{
    //[SerializeField] private Vector3 destination;
    private NavMeshAgent agent;

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

    /* Worker bee abilities:
     * 
     * work (collect honey)
     * repair building
     * build buildings
     * attack
     */
}
