using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpHeight;
    [Tooltip("Max speed the player can move")]
    public float MaxSpeed;
    [Tooltip("The fall Reset Height")]
    public float KillBox;
    public static float MS;
    public static float JH;
    public GameObject CheckPoint;
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
        if (gameObject.transform.position.y < KillBox)
        {
            gameObject.transform.position = CheckPoint.transform.position;
        }
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
     if(Inair == false)
        {
            PlayerRB.AddForce(MoveDiection.transform.up * JH, ForceMode.VelocityChange);
            Inair = true;
        }   
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CheckPoint")
        {
            CheckPoint = other.gameObject;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            Inair = false;
        }
    }
}