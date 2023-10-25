using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed;

    public void Update()
    {
        transform.Translate(Vector3.forward * MoveSpeed);
        transform.LookAt(Player.transform.position);
    }
}
