using UnityEngine;

public interface IMoveable
{
    void Move(Vector3 destination);
    void StopMoving();
}
