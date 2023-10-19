using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
public class CameraControls : MonoBehaviour
{
    public GameObject Body;
    public GameObject CameraRig;
    public float GyroSens;
    public float gyroangleYoffset;
    public float gyroangleZoffset;
    public float gyroangleXoffset;
    

    private void Start()
    {
        Input.gyro.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        CameraRig.transform.localRotation = GyroToUnity(Input.gyro.attitude);
    }
    Quaternion GyroToUnity(Quaternion quat)
    {
        return new Quaternion(quat.x, quat.z, quat.y, -quat.w);
    }
}
