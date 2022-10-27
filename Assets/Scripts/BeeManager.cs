/*
 * REFACTOR NEEDED
 * 
 * TODO: separate selection box to its own gameobject
 */



using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Diagnostics;
using UnityEngine.Events;

public class BeeManager : MonoBehaviour
{
    public List<GameObject> selectedBees;
    public List<GameObject> bees;
    public GameObject waypoint;
    public GameObject beePrefab;
    private GameObject[] testBees;
    private UnityEvent highlightEvent;

    //box select
    [SerializeField] private Vector2 startPoint;
    [SerializeField] private Vector2 currentPoint;
    [SerializeField] private bool framePassed = false;
    [SerializeField] private bool boxSelectionActive = false;

    private void Start()
    {
        selectedBees = new List<GameObject>();
        bees = new List<GameObject>();
        waypoint = GameObject.FindGameObjectWithTag("Waypoint");
        beePrefab = GameObject.Find("BeeTest");


        //add test bees to list of bees - DELETE THIS LATER
        testBees = GameObject.FindGameObjectsWithTag("Bee");
        foreach(GameObject bee in testBees)
        {
            bees.Add(bee);
        }

        SpawnBee(new Vector3(12.1862545f, -3.32999992f, -100.55748f));
        SpawnBee(new Vector3(-4.18597031f, -3.19000006f, -107.707344f));
        SpawnBee(new Vector3(3.62885189f, -2.82999992f, -108.781898f));

        if(highlightEvent == null)
        {
            highlightEvent = new UnityEvent();
        }
        highlightEvent.AddListener(CheckHighlightedBees);
    }

    void Update()
    {
        SpecificSelection();
        BoxSelection();
        SetWaypoint();   
    }

    void SetWaypoint()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Terrain")
                {
                    waypoint.transform.position = hit.point;
                    SetBeeDestination(waypoint.gameObject.transform.position);
                }
            }
        }
    }

    void SpecificSelection()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            ProcessSelection();
        }

        else if (Input.GetMouseButtonDown(0))
        {
            selectedBees.Clear();
            ProcessSelection();
        }
    }

    void BoxSelection()
    {
        if (Input.GetMouseButton(0))
        {
            if (framePassed)
            {
                //currentPoint = Input.mousePosition;
                currentPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition); // values 0 to 1
            }
            else
            {
                //startPoint = Input.mousePosition;
                startPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition); // values 0 to 1

                framePassed = true;
                boxSelectionActive = true;
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            boxSelectionActive = false;
            framePassed = false;
        }
    }

    void SetBeeDestination(Vector3 destination)
    {
        foreach(GameObject bee in selectedBees)
        {
            bee.GetComponent<BeeMovement>().destination = destination;
        }
    }

    void SpawnBee(Vector3 location)
    {
        GameObject bee = Instantiate(beePrefab, location, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        bees.Add(bee);
    }

    void CheckHighlightedBees()
    {
        foreach(GameObject bee in bees)
        {
            if (selectedBees.Contains(bee))
            {
                bee.gameObject.GetComponent<Bee>().isHighlighted = true;
            }
            else
            {
                bee.gameObject.GetComponent<Bee>().isHighlighted = false;
            }
        }
    }

    void ProcessSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Bee")
            {
                if (!selectedBees.Contains(hit.transform.gameObject))
                {
                    selectedBees.Add(hit.transform.gameObject);
                }
            }
            else if (hit.transform.tag == "Terrain")
            {
                selectedBees.Clear();
            }
        }
        highlightEvent.Invoke();
    }

}
