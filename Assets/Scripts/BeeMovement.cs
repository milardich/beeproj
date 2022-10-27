using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public Vector3 destination;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = this.transform.position;
        Move(this.transform.position);
    }

    void Update()
    {
        Move(destination);
    }

    void Move(Vector3 position)
    {    
        agent.destination = position;
    }
}
