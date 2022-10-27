/*
 * REFACTOR NEEDED
 * 
 * TODO: only selected bees move to waypoint
 */



using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MouseRaycast : MonoBehaviour
{
    public List<GameObject> selectedBees;
    public GameObject waypoint;

    private void Start()
    {
        selectedBees = new List<GameObject>();
        waypoint = GameObject.FindGameObjectWithTag("Waypoint");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
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
        }

        else if (Input.GetMouseButtonDown(0))
        {
            selectedBees.Clear();
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
        }

        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Terrain")
                {
                    waypoint.transform.position = hit.point;
                    MoveSelectedBees(waypoint.gameObject.transform.position);
                }
            }
        }
    }

    void MoveSelectedBees(Vector3 destination)
    {
        foreach(GameObject bee in selectedBees)
        {
            bee.GetComponent<BeeMovement>().destination = destination;
        }
    }
}
