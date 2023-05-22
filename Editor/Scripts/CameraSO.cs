using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSO", menuName = "CameraSO")]
public class CameraSO : ScriptableObject
{
    public float maxRightSwivelAngle = 145;
    public float maxLeftSwivelAngle = 215;
    public float baseMoveSpeed;
    public float rotateSpeed;
    public float stopDuration;
    public float stopSpeed = 50;
   

    [Header("2d/3D Camera Position for Game modes")]
    public Vector3 _2dCamPos_2P = new Vector3(0f, 0.81f, -0.5f);
    public Vector3 _2dCamPos_3P = new Vector3(0f, 0.64f, -0.40f);
    public Vector3 _3dCampos = new Vector3(0f, 1.75f, -0.1f);
    public Vector3 _current2DCamPos;
    [Header("2D/3D Camera Rotation for Game modes")]
    public Vector3 _3dCamRot = new Vector3(40f, 160f, 0f);
    public Vector3 _2dCamRot = new Vector3(90, 90, 270);
}
