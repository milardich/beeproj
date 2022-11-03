using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class Building : Unit, IWorkplace
{
    private string workName = "Barracks [test]";
    private List<IWorker> workers;
    [SerializeField] private Vector3 spawnWaypoint;
    private InputManager inputManager;

    //spawnable objects
    [SerializeField] private List<Unit> spawnableUnits;
    [SerializeField] private WorkerBee workerBee;
    // private WarriorBee warriorBee...

    void Awake()
    {
        workers = new List<IWorker>();
        spawnableUnits = new List<Unit>();
    }

    new void Start()
    {
        base.Start();
        inputManager = InputManager.Instance;
        if(!spawnableUnits.Contains(workerBee)) {
            spawnableUnits.Add(workerBee);
        }
    }

    void Update()
    {
        if(this.IsSelected()) {
            if(Input.GetMouseButtonDown(inputManager.mouseSecondary)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit)) {
                    spawnWaypoint = hit.point;
                }
            }
        }

        if(this.IsSelected()) {
            SpawnBee(spawnWaypoint);
        }
    }


    #region IWorkplace
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
    #endregion

    void SpawnBee(Vector3 waypoint)
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            WorkerBee bee = Instantiate(workerBee, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            bee.Move(waypoint);
        }
    }

    /*
     * Barracks abilities:
     * 
     * upgrade building levels (costs resource and unlocks new units)
     * [ ] spawn melee bees (fast but small dmg)
     * spawn tank bees (slow but big dmg)
     * shoot at nearby enemies on max lvl
     */
}
