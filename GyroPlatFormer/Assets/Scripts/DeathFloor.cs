using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    public Vector3 MoveDirection;

    public void Update()
    {
        transform.Translate(MoveDirection * Time.deltaTime);
    }
}
