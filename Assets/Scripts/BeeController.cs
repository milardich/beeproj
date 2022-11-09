using UnityEngine;

public class BeeController : MonoBehaviour
{
    private InputManager inputManager;
    private UnitManager unitManager;
    /* 
     * move selected units
    */

    void Start()
    {
        inputManager = InputManager.Instance;
        unitManager = UnitManager.Instance;
    }

    void Update()
    {
        //ControllSelectedBees();
        if (Input.GetKeyDown(inputManager.stop))
        {
            StopMovingSelectedUnits();
        }
    }

    /*
    void ControllSelectedBees()
    {
        if (Input.GetMouseButtonDown(inputManager.mouseSecondary))
        {
            Vector3 destination = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                MoveBeesOnTerrain(hit);
                SendBeesToWork(hit);
            }
        }
    }

    void MoveBeesOnTerrain(RaycastHit hit)
    {
        Vector3 destination = Vector3.zero;
        IMoveable moveable;
        IWorker worker;

        if (hit.transform.tag == "Terrain")
        {
            destination = hit.point;
            foreach (Unit unit in unitManager.SelectedUnits)
            {
                bool canMove = unit.TryGetComponent<IMoveable>(out moveable);
                bool isWorker = unit.TryGetComponent<IWorker>(out worker);
                if (canMove)
                {
                    moveable.Move(destination);
                }

                if (isWorker)
                {
                    if (worker.IsWorking)
                    {
                        worker.StopWorking();
                    }
                }

            }
        }
    }

    
    void SendBeesToWork(RaycastHit hit)
    {
        IWorkplace workplace;
        IWorker worker;
        IMoveable moveable;

        bool isWorkplace = hit.transform.TryGetComponent<IWorkplace>(out workplace);
        if (isWorkplace)
        {
            foreach (Unit unit in unitManager.SelectedUnits)
            {
                bool isWorker = unit.TryGetComponent<IWorker>(out worker);
                bool canMove = unit.TryGetComponent<IMoveable>(out moveable);

                if (isWorker && canMove)
                {
                    moveable.Move(workplace.WorkLocation);
                    worker.Work(workplace);
                }
            }
        }
    }
    */

    //TODO: move this to MovementManager class or something
    void StopMovingSelectedUnits()
    {
        foreach (Unit unit in unitManager.SelectedUnits)
        {
            bool canMove = unit.TryGetComponent<IMoveable>(out IMoveable moveable);
            if (canMove)
            {
                moveable.StopMoving();
            }
        }
    }
}
