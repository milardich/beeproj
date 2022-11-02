using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class Building : Unit, IWorkplace
{
    private string workName = "Barracks [test]";
    private List<IWorker> workers;

    void Awake()
    {
        workers = new List<IWorker>();
    }

    new void Start()
    {
        base.Start();   
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

    /*
     * Barracks abilities:
     * 
     * upgrade building levels (costs resource and unlocks new units)
     * spawn melee bees (fast but small dmg)
     * spawn tank bees (slow but big dmg)
     * shoot at nearby enemies on max lvl
     */
}
