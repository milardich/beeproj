using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabManager : MonoBehaviour
{
    //public List<Unit> Units { get; private set; }
    public Dictionary<string, Unit> UnitPrefabs { get; private set; }
    public static PrefabManager Instance { get; private set; }

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
        UnitPrefabs = new Dictionary<string, Unit>();
        SetupUnitDictionary();
    }

    private void SetupUnitDictionary()
    {
        UnitPrefabs.Add("Warrior", LoadUnitPrefab("WarriorBee.prefab"));
        UnitPrefabs.Add("Worker", LoadUnitPrefab("WorkerBee.prefab"));
        UnitPrefabs.Add("Barracks", LoadUnitPrefab("Barracks.prefab"));
        UnitPrefabs.Add("Nexus", LoadUnitPrefab("NexusTest.prefab"));
    }

    private Unit LoadUnitPrefab(string prefab)
    {
        string path = "Assets/Prefabs/test_prefabs2";
        return PrefabUtility.LoadPrefabContents($"{path}/{prefab}").GetComponent<Unit>();
    }
}
