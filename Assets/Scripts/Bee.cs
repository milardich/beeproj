/*
 * TODO: refactor everything
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bee : MonoBehaviour
{
    [SerializeField] private BeeManager beeManager;
    public bool isHighlighted;
    private GameObject highlightPrefab;
    [SerializeField] private Vector3 destination;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject waypoint;

    private void Start()
    {
        beeManager = GameObject.Find("BeeManager").GetComponent<BeeManager>();
        if (!beeManager.bees.Contains(this.gameObject))
        {
            beeManager.bees.Add(this.gameObject);
        }
        isHighlighted = false;
        highlightPrefab = this.transform.GetChild(1).gameObject;
        lineRenderer = this.GetComponent<LineRenderer>();
        agent = this.GetComponent<NavMeshAgent>();
        waypoint = this.gameObject.transform.GetChild(2).gameObject;
    }

    void LateUpdate()
    {
        ManageHighlight();
    }

    public void ManageHighlight()
    {
        if (isHighlighted)
        {
            HighlightOn();
            destination = agent.destination;
            waypoint.transform.position = destination;
            lineRenderer.enabled = true;
            RenderLineToDestination();
            waypoint.SetActive(true);
            waypoint.transform.position = destination;
            RenderWaypoint();
        }
        else
        {
            HighlightOff();
            lineRenderer.enabled = false;
            waypoint.SetActive(false);
        }
    }

    public void HighlightOn()
    {
        highlightPrefab.SetActive(true);
    }

    public void HighlightOff()
    {
        highlightPrefab.SetActive(false);
    }

    public void RenderLineToDestination()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, destination);
    }

    public void RenderWaypoint()
    {
        if(agent.remainingDistance > 1f)
        {
            waypoint.SetActive(true);
        }
        else
        {
            waypoint.SetActive(false);
        }
    }
}
