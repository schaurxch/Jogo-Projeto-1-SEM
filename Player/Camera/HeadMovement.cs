using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{

    public float rotation = 90.0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        this.HeadRotation();
    }

    private void HeadRotation()
    {
        float rotationX = transform.rotation.eulerAngles.x;
        bool breakUp = false;
        bool breakDown = false;
        bool move = true;
        float mouseY = Input.GetAxis("Mouse Y");

        if (rotationX >= 0 && rotationX <= 90)
        {
            if(mouseY * -1 +  rotationX >= 75)
            {
                breakDown = true;
                transform.rotation = Quaternion.Euler(75, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        if(rotationX >= 270 && rotationX <= 360)
        {
            if(mouseY * -1 + rotationX <= 280)
            {
                breakUp = true;
                transform.rotation = Quaternion.Euler(280, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        if(mouseY < 0 && breakDown)
        {
            move = false;
        }
        if (mouseY > 0 && breakUp)
        {
            move = false;
        }
        if (move)
        {
            transform.Rotate(new Vector3(mouseY * this.rotation * Time.deltaTime * -1, 0, 0));
        }
    }












}
