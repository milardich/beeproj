using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 mousePosition;
    [SerializeField] Vector3 cameraPosition;
    [SerializeField] bool movingUp = false;
    [SerializeField] bool movingDown = false;
    [SerializeField] bool movingLeft = false;
    [SerializeField] bool movingRight = false;
    [SerializeField] float cameraMoveSpeed = 20f;
    [SerializeField] int cameraBoundsSize = 5;

    void Start()
    {
        cameraPosition = transform.position;
    }

    void Update()
    {
        mousePosition = Input.mousePosition;

        if (Input.mousePosition.x < cameraBoundsSize)
        {
            movingLeft = true;
        }
        else
        {
            movingLeft = false;
        }

        if(Input.mousePosition.y < cameraBoundsSize)
        {
            movingDown = true;
        }
        else
        {
            movingDown = false;
        }

        if(Input.mousePosition.x > Screen.width - cameraBoundsSize)
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }

        if(Input.mousePosition.y > Screen.height - cameraBoundsSize)
        {
            movingUp = true;
        }
        else
        {
            movingUp = false;
        }
    }

    void FixedUpdate()
    {
        if (movingUp)
        {
            this.gameObject.transform.Translate(new Vector3(0.0f, 0.0f, cameraMoveSpeed * Time.deltaTime));
        }
        if (movingLeft)
        {
            this.gameObject.transform.Translate(new Vector3(-cameraMoveSpeed * Time.deltaTime, 0.0f , 0.0f));
        }
        if (movingDown)
        {
            this.gameObject.transform.Translate(new Vector3(0.0f, 0.0f, -cameraMoveSpeed * Time.deltaTime));
        }
        if (movingRight)
        {
            this.gameObject.transform.Translate(new Vector3(cameraMoveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
    }
}
