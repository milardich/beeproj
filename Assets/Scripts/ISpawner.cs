using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
    List<Unit> SpawnableUnits { get; set; }
    void Spawn(Unit unit, Vector3 waypoint);
}
