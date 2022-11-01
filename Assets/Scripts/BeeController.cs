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
        if (Input.GetMouseButtonDown(inputManager.mouseSecondary))
        {
            Vector3 destination = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            IMoveable moveable;

            if(Physics.Raycast(ray, out hit))
            {
                destination = hit.point;
                foreach (Unit unit in unitManager.SelectedUnits)
                {
                    bool canMove = unit.TryGetComponent<IMoveable>(out moveable);
                    if (canMove)
                    {
                        moveable.Move(destination);
                    }
                }
            }
        }    
    }
}
