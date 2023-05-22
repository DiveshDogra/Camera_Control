using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CameraEvents 
{
    public static event Action<Vector3> StopCam;

    public static void StopCamEventCaller(Vector3 direction)
    {
        StopCam?.Invoke(direction);
    }
}
