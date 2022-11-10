using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : Unit, ISpawner, IWorkplace
{
    public List<Unit> SpawnableUnits { get; set; }
    public List<IWorker> Workers { get; set; }
    public string Name => "Nexus";
    public Vector3 WorkLocation => this.transform.position;

    public WorkType WorkType => WorkType.UnloadHoney;

    private InputManager inputManager;
    private PrefabManager prefabManager;
    [SerializeField] private Vector3 spawnWaypoint;
    private RaycastHit hit;

    private void Awake()
    {
        this.SpawnableUnits = new List<Unit>();
        this.Workers = new List<IWorker>();
    }

    new void Start()
    {
        base.Start();
        inputManager = InputManager.Instance;
        prefabManager = PrefabManager.Instance;
        if (!UnitManager.Instance.AllNexuses.Contains(this))
        {
            UnitManager.Instance.AllNexuses.Add(this);
        }
        SpawnableUnits.Add(prefabManager.UnitPrefabs["Worker"]);
    }

    private void Update()
    {
        ManageWaypoint();
        ManageSpawning();
    }

    public void AddWorker(IWorker worker)
    {
        Workers.Add(worker);
    }

    public void ProcessWork()
    {
        Debug.Log("Bee has delivered honey! (honeyAmount++)");
    }

    public void RemoveWorker(IWorker worker)
    {
        Workers.Remove(worker);
    }

    public void Spawn(Unit unit, Vector3 waypoint)
    {
        Unit spawnedUnit = Instantiate(unit, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        bool canMove = spawnedUnit.TryGetComponent<IMoveable>(out IMoveable moveable);
        if (canMove)
        {
            moveable.Move(waypoint);
        }
    }

    private void ManageSpawning()
    {
        if (this.IsSelected())
        {
            if (Input.GetKeyDown(inputManager.spawnWorkerBee))
            {
                Spawn(SpawnableUnits[0], spawnWaypoint);
            }
        }
    }

    private void ManageWaypoint()
    {
        if (this.IsSelected())
        {
            if (Input.GetMouseButtonDown(inputManager.mouseSecondary))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    bool isWorkplace = hit.transform.TryGetComponent<IWorkplace>(out IWorkplace workplace);
                    if (isWorkplace)
                    {
                        spawnWaypoint = workplace.WorkLocation;
                    }
                    else
                    {
                        spawnWaypoint = hit.point;
                    }
                }
            }
        }
    }
}
