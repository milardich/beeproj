using System.Collections.Generic;
using UnityEngine;

public class Barracks : Unit, IWorkplace
{
    /*
     * spawnable units:
     *  (lv.1)
     *      -melee bee
     *  (lv.2)
     *      -tanky but slow bee
     *  ]
     */
    new void Start()
    {
        base.Start();
    }

    public List<IWorker> Workers => throw new System.NotImplementedException();

    public string Name => throw new System.NotImplementedException();

    public Vector3 WorkLocation => throw new System.NotImplementedException();

    public void AddWorker(IWorker worker)
    {
        throw new System.NotImplementedException();
    }

    public void ProcessWork()
    {
        throw new System.NotImplementedException();
    }

    public void RemoveWorker(IWorker worker)
    {
        throw new System.NotImplementedException();
    }
}
