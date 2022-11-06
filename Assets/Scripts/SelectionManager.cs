using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private InputManager inputManager;
    private UnitManager unitManager;
    private int selectableLayerMask;

    void Awake()
    {
        selectableLayerMask = LayerMask.GetMask("Selectable");
    }

    void Start()
    {
        inputManager = InputManager.Instance;
        unitManager = UnitManager.Instance;
    }

    void Update()
    {
        ClickSelect();
        SelectAllMoveables();
    }


    /*
     * Selectable layer mask is used to deselect all units in case of
     * clicking on objects that are not in that same layer mask
     */
    public void ProcessSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayerMask))
        {
            ISelectable selectable = hit.collider.GetComponent<ISelectable>();
            if (selectable != null)
            {
                selectable.Select();
            }
        }
        else
        {
            unitManager.DeselectAllUnits();
        }
    }

    public void ClickSelect()
    {
        if (Input.GetMouseButtonDown(inputManager.mousePrimary))
        {
            if (!Input.GetKey(inputManager.groupSelect))
            {
                unitManager.DeselectAllUnits();
            }
            ProcessSelection();
        }
    }

    public void SelectAllMoveables()
    {
        if (Input.GetKeyDown(inputManager.selectAllBees))
        {
            unitManager.DeselectAllUnits();
            foreach (Unit unit in unitManager.Units)
            {
                bool isMoveable = unit.TryGetComponent<IMoveable>(out IMoveable moveable);
                if (isMoveable && !unit.IsSelected())
                {
                    unit.Select();
                }
            }
        }
    }

    //TODO: drag select
    //TODO: ctrl click/drag select (holding ctrl and selecting adds units to selectedUnits)
}
