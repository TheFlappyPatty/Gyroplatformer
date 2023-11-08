using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject GyroPlayer;
    public GameObject DebugPlayer;
    public void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (SystemInfo.supportsGyroscope)
        {
            Instantiate(GyroPlayer,transform.position,Quaternion.identity,null);
        }
        else
        {
            Instantiate(DebugPlayer, transform.position, Quaternion.identity, null);
        }
    }
}
