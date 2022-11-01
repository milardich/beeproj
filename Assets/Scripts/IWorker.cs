using UnityEngine;

public interface IWorker 
{
    int WorkPerformance { get; }
    void Work(IWorkplace workPlace);
    void StopWorking();
    IWorkplace CurrentWorkplace();
    /*
     * workPlace would be places such as places for collecting honey,
     * repairing specific building etc
     */
}
