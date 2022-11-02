using UnityEngine;

public interface IWorker 
{
    int WorkPerformance { get; }
    bool IsWorking { get; set; }
    void Work(IWorkplace workPlace);
    void StopWorking();
    IWorkplace CurrentWorkplace { get; }
    /*
     * workPlace would be places such as places for collecting honey,
     * repairing specific building etc
     */
}
