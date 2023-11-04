using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class CameraControls : MonoBehaviour
{
    public GameObject Body;
    public GameObject CameraRig;

    [Event(3)]
    public IEnumerator Debugmode()
    {
        return null;
    }

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            CameraRig.transform.position = Body.GetComponentInChildren<Transform>().position;
            CameraRig.transform.localRotation = GyroToUnity(Input.gyro.attitude);
            Body.transform.eulerAngles = new Vector3(0, CameraRig.transform.eulerAngles.y, 0);
        }
    }
    Quaternion GyroToUnity(Quaternion quat)
    {
        return new Quaternion(quat.x, quat.z, quat.y, -quat.w);
    }
}
