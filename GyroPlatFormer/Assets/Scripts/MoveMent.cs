using Palmmedia.ReportGenerator.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMent : MonoBehaviour
{

    //Character Config
    [Tooltip("How fast the player will accelerate")]
    public float MovementSpeed;
    [Tooltip("Jump Strengh")]
    public float JumpHeight;
    [Tooltip("Max speed the player can move")]
    public float MaxSpeed;
    [Tooltip("The fall Reset Height")]
    public float DeathHieght;
    public float SlideResistance;

    //Static Varables for other scripts
    public static float MS;
    public static float JH;
   private static Rigidbody PlayerRB;
    private static GameObject MoveDiection;
    //Checkpoint and Death systems
    public GameObject CheckPoint;
    public Vector3 DeathBoxPos;
    public GameObject DeathWall;

    //Player States
    public static bool Inair = false;
    public bool IsMoving;

    public void Start()
    {
        JH = JumpHeight;
        MS = MovementSpeed;
        PlayerRB = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (gameObject.transform.position.y < DeathHieght)
        {
            Death();
        }
        MoveDiection = GameObject.Find("PlayerHead");
        if (IsMoving == false && Inair == false)
        {
            PlayerRB.AddForce(Vector3.zero, ForceMode.VelocityChange);
            Debug.LogError("if you see this there is no god");
        }
        if (PlayerRB.velocity.magnitude > MaxSpeed)
        {
            PlayerRB.velocity = PlayerRB.velocity.normalized * MaxSpeed;
        }
    }
    public void Death()
    {
        gameObject.transform.position = CheckPoint.transform.position;
        DeathWall.transform.position = DeathBoxPos;
    }
    public static void moveforward()
    {
        PlayerRB.AddForce(MoveDiection.transform.forward.normalized * MS, ForceMode.Acceleration);
    }
    public static void moveBack()
    {
        PlayerRB.AddForce(-MoveDiection.transform.forward.normalized * MS, ForceMode.Acceleration);
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
            DeathBoxPos = DeathWall.transform.position;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            Inair = false;
        }
        if(collision.transform.tag == "DeathFloor")
        {
            Death();
        }
    }
}
