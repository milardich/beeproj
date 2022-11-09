using UnityEngine;

public class HoneyBucket : MonoBehaviour
{
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; private set; } // TODO: (animation) increase/decrease honey amount in bucket based on this number

    private void Start()
    {
        MaxCapacity = 10;
        CurrentCapacity = 0;
    }

    public void FillUp(int amount)
    {
        if(CurrentCapacity <= MaxCapacity)
        {
            if((CurrentCapacity + amount) >= MaxCapacity)
            {
                CurrentCapacity = MaxCapacity;
            }
            else
            {
                CurrentCapacity += amount;
            }
        }
    }

    public void Empty(int amount)
    {
        if(CurrentCapacity >= 0)
        {
            if((CurrentCapacity - amount) <= 0)
            {
                CurrentCapacity = 0;
            }
            else
            {
                CurrentCapacity -= amount;
            }
        }
    }
}
