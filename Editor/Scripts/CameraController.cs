using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CameraSO _cameraSO;
    public CameraUtility _cameraUtility;

    private void OnEnable()
    {
        CameraEvents.StopCam += StopCamera;
    }


    public void MoveCamera(Vector3 pos, Vector3 rot, float duration)
    {
        _cameraUtility.MoveCameraToPosition(pos, rot, duration);
    }


    public void RotateCameraRight()
    {
        _cameraUtility.RotateCameraRight(_cameraSO.maxRightSwivelAngle, _cameraSO.rotateSpeed, _cameraSO.baseMoveSpeed);
    }


    public void RotateCameraLeft()
    {
        _cameraUtility.RotateCameraLeft(_cameraSO.maxLeftSwivelAngle, _cameraSO.rotateSpeed, _cameraSO.baseMoveSpeed);
    }


    public void StopCamera(Vector3 direction)
    {
        _cameraUtility.StopCam(direction ,_cameraSO.stopSpeed, _cameraSO.stopDuration, _cameraSO.maxLeftSwivelAngle, _cameraSO.maxRightSwivelAngle);
    }
}
