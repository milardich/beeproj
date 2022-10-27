using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public bool isHighlighted;
    private GameObject highlightPrefab;
    private int health;

    private void Start()
    {
        isHighlighted = false;
        highlightPrefab = this.transform.GetChild(1).gameObject;
    }

    void LateUpdate()
    {
        ManageHighlight();
    }

    public void ManageHighlight()
    {
        if (isHighlighted)
        {
            HighlightOn();
        }
        else
        {
            HighlightOff();
        }
    }

    public void HighlightOn()
    {
        highlightPrefab.SetActive(true);
    }

    public void HighlightOff()
    {
        highlightPrefab.SetActive(false);
    }
}
