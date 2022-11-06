using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabManager : MonoBehaviour
{
    //public List<Unit> Units { get; private set; }
    public Dictionary<string, GameObject> Units { get; private set; }
    public static PrefabManager Instance { get; private set; }
    
    void Awake()
    {
        if(Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
        Units = new Dictionary<string, GameObject>();
        SetupUnitDictionary();
    }

    private void SetupUnitDictionary()
    {
        Units.Add("Warrior", LoadPrefab("WarriorBee.prefab"));
        Units.Add("Worker", LoadPrefab("WorkerBee.prefab"));
        Units.Add("Barracks", LoadPrefab("Barracks.prefab"));
        Units.Add("Nexus", LoadPrefab("NexusTest.prefab"));
    }

    private GameObject LoadPrefab(string prefab)
    {
        string path = "Assets/Prefabs/test_prefabs2";
        return PrefabUtility.LoadPrefabContents($"{path}/{prefab}");
    }
}
