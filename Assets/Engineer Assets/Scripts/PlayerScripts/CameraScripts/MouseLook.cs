using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

    /*  Script: MouseLook.cs
        Author: Zackary Hoyt
        Date:   2016 January 19

        Description:
        Used to Smoothly Rotate the Camera Relative to Mouse Movement
    */

    //  Rotate Camera to Face Where the Mouse is Pointing
    float rotationX = 0, rotationY = 0, lastDeltaX = 0, lastDeltaY = 0;
    public void mouseLook(float mouseDeltaX, float mouseDeltaY)
    {
        //  Average Rotation to Match Last Rotational Speed to Smooth Camera Panning
        float tX = 0.5f, tY = 0.5f;
        if (mouseDeltaX != 0) tX = 0.5f * Mathf.Abs(lastDeltaX / mouseDeltaX);
        if (mouseDeltaY != 0) tY = 0.5f * Mathf.Abs(lastDeltaY / mouseDeltaY);

        rotationX += PCSettings.staticRef.lookSensitivity.x * Mathf.Lerp(mouseDeltaX, lastDeltaX, tX);
        rotationY += PCSettings.staticRef.lookSensitivity.y * Mathf.Lerp(mouseDeltaY, lastDeltaY, tY);
        lastDeltaX = mouseDeltaX;
        lastDeltaY = mouseDeltaY;
        rotationY = Mathf.Clamp(rotationY, -PCSettings.staticRef.yRotationLimit, PCSettings.staticRef.yRotationLimit);
        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up) * Quaternion.AngleAxis(rotationY, -Vector3.right);
    }
}
