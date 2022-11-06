using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Building : Unit, IWorkplace, ISpawner
{
    private string workName = "Building [test]";
    private List<IWorker> workers;
    [SerializeField] private Vector3 spawnWaypoint;
    private InputManager inputManager;

    //spawnable objects
    public List<Unit> SpawnableUnits { get; set; }
    [SerializeField] private GameObject loadedPrefab;
    private Unit spawnableUnit;
    // private WarriorBee warriorBee...

    void Awake()
    {
        workers = new List<IWorker>();
        SpawnableUnits = new List<Unit>();
    }

    new void Start()
    {
        base.Start();
        inputManager = InputManager.Instance;

        loadedPrefab = PrefabUtility.LoadPrefabContents("Assets/Prefabs/test_prefabs2/WorkerBee.prefab");
        spawnableUnit = loadedPrefab.GetComponent<Unit>();

        if (!SpawnableUnits.Contains(spawnableUnit))
        {
            SpawnableUnits.Add(spawnableUnit);
        }
    }

    void Update()
    {
        ManageWaypoint();
        ManageSpawning();
    }


    public string Name { get => this.workName; }

    public List<IWorker> Workers { get => this.workers; }

    public void AddWorker(IWorker worker)
    {
        if (!this.Workers.Contains(worker))
        {
            this.Workers.Add(worker);
        }
    }

    public void RemoveWorker(IWorker worker)
    {
        if (this.Workers.Contains(worker))
        {
            this.Workers.Remove(worker);
        }
    }

    public Vector3 WorkLocation { get => this.transform.position; }

    public void ProcessWork()
    {
        // if building is damaged, bee's work would be to repair damages (heal building)
        Debug.Log($"Building [ {this.Name} ] is being repaired");
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

    public void ManageSpawning()
    {
        if (this.IsSelected())
        {
            if (Input.GetKeyDown(inputManager.spawnWorkerBee))
            {
                Spawn(SpawnableUnits[0], spawnWaypoint);
            }
        }
    }

    public void ManageWaypoint()
    {
        if (this.IsSelected())
        {
            if (Input.GetMouseButtonDown(inputManager.mouseSecondary))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    spawnWaypoint = hit.point;
                }
            }
        }
    }

    /*
     * Barracks abilities:
     * 
     * upgrade building levels (costs resource and unlocks new units)
     * [X] spawn melee bees (fast but small dmg)
     * spawn tank bees (slow but big dmg)
     * shoot at nearby enemies on max lvl
     */
}
