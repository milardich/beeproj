using System.Collections.Generic;
using UnityEngine;

public interface IWorkplace
{
    List<IWorker> Workers { get; }
    string Name { get; }
    void AddWorker(IWorker worker);
    void RemoveWorker(IWorker worker);
    Vector3 WorkLocation { get; }
    void ProcessWork();
    /*
     * for buildings, bees would work on repairing damages, upgrading maybe
     * for Collectible zones/flower zones, bees would work on collecting honey
     */
}
