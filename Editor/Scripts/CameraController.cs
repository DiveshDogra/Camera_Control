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
    private void Start()
    {
        SetStartCamera();
    }

    public void SetStartCamera()
    {
        _cameraUtility.MoveCameraToPosition(_cameraSO._3dCampos, _cameraSO._3dCamRot, _cameraSO.baseMoveSpeed);
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
