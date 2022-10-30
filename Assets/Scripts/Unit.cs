using UnityEngine;

public class Unit : MonoBehaviour, ISelectable, IHighlightable
{
    [SerializeField] private bool isSelected;
    private UnitManager unitManager;
    private GameObject highlightCircle;

    public void Highlight()
    {
        highlightCircle.SetActive(true);
    }

    public void Dehighlight()
    {
        highlightCircle.SetActive(false);
    }

    public bool IsSelected()
    {
        return isSelected;
    }

    public void Select()
    {
        this.isSelected = true;
        /* when unit is selected: */
        // add unit to list of selected units (with UnitManager(singleton class))
        if (!UnitManager.Instance.SelectedUnits.Contains(this))
        {
            UnitManager.Instance.SelectedUnits.Add(this);
        }

        // show selection highlight (circle below unit, outline, show health)
        Highlight();

        // display unit info and abilities in UI
        //

        Debug.Log("Selected: " + this.name);
    }

    public void Deselect()
    {
        this.isSelected = false;
        /* when unit is unselected: */
        // remove from list of selected units
        if (UnitManager.Instance.SelectedUnits.Contains(this))
        {
            UnitManager.Instance.SelectedUnits.Remove(this);
        }
        Dehighlight();
        Debug.Log("Deselected: " + this.name);
    }

    void Start()
    {
        //  null reference exception ???
        
        if (!UnitManager.Instance.Units.Contains(this))
        {
            UnitManager.Instance.Units.Add(this);
        }
        
        highlightCircle = this.transform.GetChild(0).gameObject;
    }
}
