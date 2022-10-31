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
    }

    
    /*
     * Selectable layer mask is used to deselect all units in case of
     * clicking on objects that are not in that same layer mask
     */
    public void ProcessSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayerMask))
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
        if (Input.GetMouseButtonDown(inputManager.mouseLeft))
        {
            if (!Input.GetKey(inputManager.groupSelect))
            {
                unitManager.DeselectAllUnits();
            }
            ProcessSelection();
        }
    }

    //TODO: drag select
    //TODO: ctrl click/drag select (holding ctrl and selecting adds units to selectedUnits)
}
