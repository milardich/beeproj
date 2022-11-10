using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersManager : MonoBehaviour
{
    public List<IWorkplace> AllFlowers { get; private set; }
    public static FlowersManager Instance { get; private set; }

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
        AllFlowers = new List<IWorkplace>();
    }
}
