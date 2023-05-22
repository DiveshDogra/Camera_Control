using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraUtility : MonoBehaviour
{
    public GameObject lookAtObject;

    public void MoveCameraToPosition(Vector3 cameraPos, Vector3 cameraRot , float duration)
    {
        transform.DOLocalRotate(cameraRot, duration).OnUpdate(
                () => CameraLookAt(lookAtObject));
        transform.DOMove(cameraPos, duration);
    }

    public void CameraLookAt(GameObject lookAtObject)
    {
        if (lookAtObject != null)
        {
            transform.GetChild(0).transform.DOLookAt(lookAtObject.transform.position, Time.deltaTime);
        }
    }

    public void RotateCameraRight(float maxRightSwivelAngle, float rotateSpeed, float duration)
    {
        if (transform.localRotation.eulerAngles.y >= maxRightSwivelAngle)
        {
            transform.DOLocalRotate(Vector3.down * rotateSpeed * Time.deltaTime, 0.1f).SetEase(Ease.Linear).SetRelative().OnUpdate(
            () => CameraLookAt(lookAtObject)).OnComplete(() => CameraEvents.StopCamEventCaller(Vector3.down));
        }
    }

    public void RotateCameraLeft(float maxLeftSwivelAngle, float rotateSpeed, float duration)
    {
        if (transform.localRotation.eulerAngles.y <= maxLeftSwivelAngle)
        {
            transform.DOLocalRotate(Vector3.up * rotateSpeed * Time.deltaTime, 0.1f).SetEase(Ease.Linear).SetRelative().OnUpdate(
            () => CameraLookAt(lookAtObject)).OnComplete(() => CameraEvents.StopCamEventCaller(Vector3.up));
        }
    }

    public void StopCam(Vector3 direction, float stopSpeed, float stopDuration , float maxLeftSwivelAngle, float maxRightSwivelAngle)
    {
        DOVirtual.Float(stopSpeed, 0, stopDuration, x =>
        {
            if (transform.localRotation.eulerAngles.y <= maxLeftSwivelAngle && transform.localRotation.eulerAngles.y >= maxRightSwivelAngle)
            {
                transform.DOLocalRotate(direction * x * Time.deltaTime, 0.1f).SetEase(Ease.Linear).SetRelative().OnUpdate(
                () => transform.GetChild(0).transform.DOLookAt(lookAtObject.transform.position, Time.deltaTime));
            }
        });
    }
}
