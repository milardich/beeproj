public interface IWorker
{
    float WorkPerformance { get; }
    bool IsWorking { get; set; }
    void Work(IWorkplace workPlace);
    void StopWorking();
    IWorkplace CurrentWorkplace { get; set; }
    bool WorkDone { get; set; }
    /*
     * workPlace would be places such as places for collecting honey,
     * repairing specific building etc
     */
}
