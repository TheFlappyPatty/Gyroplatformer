using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
public class CameraControls : MonoBehaviour
{
    public GameObject Body;
    public GameObject CameraRig;
    

    private void Start()
    {
        Input.gyro.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        CameraRig.transform.position = Body.GetComponentInChildren<Transform>().position;
        CameraRig.transform.localRotation = GyroToUnity(Input.gyro.attitude);
        Body.transform.eulerAngles = new Vector3(0,CameraRig.transform.eulerAngles.y,0);
    }
    Quaternion GyroToUnity(Quaternion quat)
    {
        return new Quaternion(quat.x, quat.z, quat.y, -quat.w);
    }
}
