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
        if (!UnitManager.Instance.SelectedUnits.Contains(this))
        {
            UnitManager.Instance.SelectedUnits.Add(this);
        }
        Highlight();
        
        Debug.Log("Selected: " + this.name);
    }

    public void Deselect()
    {
        this.isSelected = false;
        if (UnitManager.Instance.SelectedUnits.Contains(this))
        {
            UnitManager.Instance.SelectedUnits.Remove(this);
        }
        Dehighlight();
        Debug.Log("Deselected: " + this.name);
    }

    void Start()
    {        
        if (!UnitManager.Instance.Units.Contains(this))
        {
            UnitManager.Instance.Units.Add(this);
        }
        highlightCircle = this.transform.GetChild(0).gameObject;
    }
}
