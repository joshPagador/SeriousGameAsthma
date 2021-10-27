using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class PlayerCamera : MonoBehaviour
{

    public Transform cam;

    //camera variables
    public float camRotationSpeed = 5f;
    public float cameraMinY = -60f;
    public float cameraMaxY = 75f;
    public float rotationSmoothSpeed = 10f;

    float bodyRotationX;
    float cameraRotationY;

    private void Awake()
    {
        MouseCursorManager.Instance.ActivateFirstPersonControl();
    }

    void Update()
    {
        LookRotation();
    }

    void LookRotation()
    {
        bodyRotationX += Input.GetAxis("Mouse X") * camRotationSpeed;
        cameraRotationY += Input.GetAxis("Mouse Y") * camRotationSpeed;

        //Limiting camera rotation on Y axis
        cameraRotationY = Mathf.Clamp(cameraRotationY, cameraMinY, cameraMaxY);

        //Rotation handling
        Quaternion cameraTargetRot = Quaternion.Euler(-cameraRotationY, 0, 0);
        Quaternion bodyTargetRot = Quaternion.Euler(0, bodyRotationX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, bodyTargetRot, Time.deltaTime * rotationSmoothSpeed);
        cam.localRotation = Quaternion.Lerp(cam.localRotation, cameraTargetRot, Time.deltaTime * rotationSmoothSpeed);
    }
}

