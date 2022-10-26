using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] bool movingUp = false;
    [SerializeField] bool movingDown = false;
    [SerializeField] bool movingLeft = false;
    [SerializeField] bool movingRight = false;
    [SerializeField] float cameraMoveSpeed = 50.0f;
    [SerializeField] int cameraMoveBounds = 5;
    [SerializeField] float scrollSpeed = 3.0f;
    private float minCameraHeight = 5.0f;
    float maxCameraHeight = 40.0f;

    private void Start()
    {
        this.gameObject.transform.position = new Vector3(0.0f, 40.0f, -140.0f);
    }

    void Update()
    {
        movingLeft = Input.mousePosition.x < cameraMoveBounds;
        movingDown = Input.mousePosition.y < cameraMoveBounds;
        movingRight = Input.mousePosition.x > Screen.width - cameraMoveBounds;
        movingUp = Input.mousePosition.y > Screen.height - cameraMoveBounds;

        MoveUp();
        MoveLeft();
        MoveRight();
        MoveDown();
        Zoom();
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

    public void Zoom()
    {
        Vector3 pos = this.gameObject.transform.position;
        pos.y -= Input.mouseScrollDelta.y * scrollSpeed;
        if (pos.y >= minCameraHeight && pos.y <= maxCameraHeight)
        {
            this.gameObject.transform.position = pos;
        }
        else if (pos.y > maxCameraHeight)
        {
            this.gameObject.transform.position = new Vector3(pos.x, maxCameraHeight, pos.z);
        }
        else
        {
            this.gameObject.transform.position = new Vector3(pos.x, minCameraHeight, pos.z);
        }   
    }
}
