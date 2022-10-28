/*
 * REFACTOR NEEDED
 * 
 * TODO: separate selection stuff to its own script
 */



using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Diagnostics;
using UnityEngine.Events;

public class BeeManager : MonoBehaviour
{
    public List<GameObject> selectedBees;
    public List<GameObject> bees;
    [SerializeField] private GameObject beePrefab;
    private GameObject[] testBees;
    private UnityEvent highlightEvent;

    [Header("Box selection stuff")]
    [SerializeField] RectTransform boxVisual; //graphical
    private Rect selectionBox; //logical
    [SerializeField] Vector2 startPosition;
    [SerializeField] Vector2 endPosition;
    Camera myCam;

    private void Start()
    {
        selectedBees = new List<GameObject>();
        bees = new List<GameObject>();
        beePrefab = GameObject.Find("BeeTest");

        // box selection stuff
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();

        
        testBees = GameObject.FindGameObjectsWithTag("Bee");
        foreach(GameObject bee in testBees)
        {
            if (!bees.Contains(bee))
            {
                bees.Add(bee);
            }
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
        ClickSelection();
        DragSelection();
        SetWaypoint();
    }


    private void DragSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }

        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
            SelectUnits();
        }

        if (Input.GetMouseButtonUp(0))
        {
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
        }
        
    }

    private void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;
        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;
        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
        boxVisual.sizeDelta = boxSize;
    }

    private void DrawSelection()
    {
        if(Input.mousePosition.x < startPosition.x)
        {
            //dragging to the left
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            // dragging to the right
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < startPosition.y)
        {
            //dragging to the down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            // dragging to the up
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }

    private void SelectUnits()
    {
        foreach(GameObject bee in bees)
        {
            if (selectionBox.Contains(myCam.WorldToScreenPoint(bee.transform.position)))
            {
                if (!selectedBees.Contains(bee))
                {
                    selectedBees.Add(bee);
                    highlightEvent.Invoke();
                }
            }
        }
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
                    SetBeeDestination(hit.point);
                }
            }
        }
    }

    void ClickSelection()
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
