using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<Unit> Units { get; private set; }
    public List<Unit> SelectedUnits { get; private set; }
    public static UnitManager Instance { get; private set; }
    public List<IWorkplace> AllWorkplaces { get; private set; }
    public List<IWorkplace> AllNexuses { get; private set; }
    public List<IWorkplace> AllFlowers { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        Units = new List<Unit>();
        SelectedUnits = new List<Unit>();
        AllWorkplaces = new List<IWorkplace>();
        AllNexuses = new List<IWorkplace>();
        AllFlowers = new List<IWorkplace>();
    }

    public void AddToSelectedUnits(Unit unit)
    {
        if (!SelectedUnits.Contains(unit))
        {
            SelectedUnits.Add(unit);
        }
    }

    public void DeselectAllUnits()
    {
        foreach (Unit unit in Units)
        {
            if (SelectedUnits.Contains(unit))
            {
                unit.Deselect();
            }
        }
    }

    public void DeselectUnit(Unit unit)
    {
        if (SelectedUnits.Contains(unit))
        {
            unit.Deselect();
        }
    }
}
