using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject Body;
    public GameObject CameraRig;
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
        CameraRig.transform.rotation = new Quaternion(Input.gyro.attitude.y + gyroangleYoffset, Input.gyro.attitude.z + gyroangleZoffset, Input.gyro.attitude.x + gyroangleXoffset, Input.gyro.attitude.w);

    }
}
