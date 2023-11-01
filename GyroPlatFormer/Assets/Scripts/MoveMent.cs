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
    public static bool IsMoving;

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
            gameObject.transform.position = CheckPoint.transform.position;
        }
        MoveDiection = GameObject.Find("PlayerHead");
        if(IsMoving == false && Inair == false)
        {
            PlayerRB.AddForce(-MoveDiection.GetComponent<Rigidbody>().velocity.normalized * SlideResistance, ForceMode.Acceleration);
        }
        IsMoving = false;
        if(PlayerRB.velocity.magnitude > MaxSpeed)
        {
            PlayerRB.velocity = PlayerRB.velocity.normalized * MaxSpeed;
        }
    }
    public static void moveforward()
    {
        PlayerRB.AddForce(MoveDiection.transform.forward.normalized * MS, ForceMode.Acceleration);
        IsMoving = true;
    }
    public static void moveBack()
    {
        PlayerRB.AddForce(-MoveDiection.transform.forward.normalized * MS, ForceMode.Acceleration);
        IsMoving = true;
    }
    public static void moveLeft()
    {
        PlayerRB.AddForce(-MoveDiection.transform.right.normalized * MS, ForceMode.Acceleration);
        IsMoving = true;
    }
    public static void moveRight()
    {
        PlayerRB.AddForce(MoveDiection.transform.right.normalized * MS, ForceMode.Acceleration);
        IsMoving = true;
    }
    public static void Jump()
    {
     if(Inair == false)
        {
            PlayerRB.AddForce(MoveDiection.transform.up * JH, ForceMode.VelocityChange);
            IsMoving = true;
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
            DeathWall.transform.position = DeathBoxPos;
            gameObject.transform.position = DeathBoxPos;
        }
    }
}
