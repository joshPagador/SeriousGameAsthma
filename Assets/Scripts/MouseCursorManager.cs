using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorManager : ManagersSingleton<MouseCursorManager>
{

    public void ActivateFirstPersonControl()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void DeactivateFirstPersonControl()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
