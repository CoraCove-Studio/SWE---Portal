//Programmer: Huggins

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Camera Calls")]
    [SerializeField] private Camera cam;
    [SerializeField] private float xRotation = 0f;
    [SerializeField] private float xSensitivity = 25f;
    [SerializeField] private float ySensitivity = 25f;
    [SerializeField] private float degreeClamp = 80f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //calculating the camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -degreeClamp, degreeClamp);

        //this applys to the cameras transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //rotating the camera to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
