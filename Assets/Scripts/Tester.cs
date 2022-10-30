using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private Unit[] units;

    private void Start()
    {
        units = GameObject.FindObjectsOfType<Unit>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            units[0].Select();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            units[0].Deselect();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            units[1].Select();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            units[1].Deselect();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Unit unit in UnitManager.Instance.Units)
            {
                Debug.Log(unit.name);
            }
        }
    }
}
