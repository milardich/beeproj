using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : Unit, IWorkplace
{
    private float baseWorkTime = 5.0f;
    public List<IWorker> Workers { get; set; }

    [SerializeField] private Unit closestNexusUnit;
    private IWorkplace closestNexusWorkplace;

    public string Name { get; set; }

    public Vector3 WorkLocation { get { return this.transform.position; } }

    public WorkType WorkType => WorkType.CollectHoney;

    void Awake()
    {
        Workers = new List<IWorker>();
    }

    new void Start()
    {
        base.Start();

        closestNexusUnit.TryGetComponent<IWorkplace>(out closestNexusWorkplace);
    }

    public void AddWorker(IWorker worker)
    {
        this.Workers.Add(worker);
    }

    public void ProcessWork()
    {
        // if worker in working range ..
        /*
        foreach(IWorker worker in Workers)
        {
            if (!worker.WorkDone)
            {
                StartCoroutine(CollectHoney(worker));
            }
        }
        */
    }

    public void RemoveWorker(IWorker worker)
    {
        this.Workers.Remove(worker);
    }

    private IEnumerator CollectHoney(IWorker worker)
    {
        // higher work performance -> less time to do work
        float workTime = (100.0f / worker.WorkPerformance) * baseWorkTime;
        Debug.Log("Work started!");
        yield return new WaitForSeconds(workTime);
        Debug.Log("Honey collected - delivering to nexus rn!");
        worker.WorkDone = true;
        
        worker.Work(closestNexusWorkplace);
    }
}
