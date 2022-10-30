using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<Unit> Units { get; private set; }
    public List<Unit> SelectedUnits { get; private set; }
    public static UnitManager Instance { get; private set; }

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
    }
}