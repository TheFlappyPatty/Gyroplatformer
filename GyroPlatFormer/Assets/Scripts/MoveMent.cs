using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpHeight;
    public float MaxSpeed;
    public static float MS;
    public static float JH;
    public static bool Inair = false;
    private static GameObject MoveDiection;
    private static Rigidbody PlayerRB;
    public void Start()
    {
        JH = JumpHeight;
        MS = MovementSpeed;
        PlayerRB = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        MoveDiection = GameObject.Find("PlayerHead");
        if(Inair == false)
        {
            PlayerRB.velocity = new Vector3(0,PlayerRB.velocity.y,0);
        }
        if(PlayerRB.velocity.magnitude > MaxSpeed)
        {
            PlayerRB.velocity = PlayerRB.velocity.normalized * MaxSpeed;
        }
    }

    public static void moveforward()
    {
        PlayerRB.AddForce(MoveDiection.transform.forward.normalized * MS, ForceMode.VelocityChange);
    }
    public static void moveBack()
    {
        PlayerRB.AddForce(-MoveDiection.transform.forward.normalized * MS, ForceMode.VelocityChange);
    }
    public static void moveLeft()
    {
        PlayerRB.AddForce(-MoveDiection.transform.right.normalized * MS, ForceMode.VelocityChange);
    }
    public static void moveRight()
    {
        PlayerRB.AddForce(MoveDiection.transform.right.normalized * MS, ForceMode.VelocityChange);
    }
    public static void Jump()
    {
        
        PlayerRB.AddForce(MoveDiection.transform.up * JH, ForceMode.VelocityChange);
        Inair = true;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            Inair = false;
        }
    }
}
