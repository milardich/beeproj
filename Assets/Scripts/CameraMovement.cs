using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] bool movingUp = false;
    [SerializeField] bool movingDown = false;
    [SerializeField] bool movingLeft = false;
    [SerializeField] bool movingRight = false;
    [SerializeField] float cameraMoveSpeed = 20f;
    [SerializeField] int cameraBoundsSize = 5;

    void Update()
    {
        movingLeft = Input.mousePosition.x < cameraBoundsSize;
        movingDown = Input.mousePosition.y < cameraBoundsSize;
        movingRight = Input.mousePosition.x > Screen.width - cameraBoundsSize;
        movingUp = Input.mousePosition.y > Screen.height - cameraBoundsSize;

        MoveUp();
        MoveLeft();
        MoveRight();
        MoveDown();
    }

    public void MoveUp()
    {
        if (movingUp)
        {
            this.gameObject.transform.Translate(new Vector3(0.0f, 0.0f, cameraMoveSpeed * Time.deltaTime));
        }
    }

    public void MoveLeft()
    {
        if (movingLeft)
        {
            this.gameObject.transform.Translate(new Vector3(-cameraMoveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
    }

    public void MoveDown()
    {
        if (movingDown)
        {
            this.gameObject.transform.Translate(new Vector3(0.0f, 0.0f, -cameraMoveSpeed * Time.deltaTime));
        }
    }

    public void MoveRight()
    {
        if (movingRight)
        {
            this.gameObject.transform.Translate(new Vector3(cameraMoveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
    }
}
