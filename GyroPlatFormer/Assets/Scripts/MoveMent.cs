using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Vector3 DeathBoxPos;
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
           // PlayerRB.velocity = new Vector3(0,PlayerRB.velocity.y,0);
        }
        if(PlayerRB.velocity.magnitude > MaxSpeed)
        {
            PlayerRB.velocity = PlayerRB.velocity.normalized * MaxSpeed;
        }
    }
    public static void ButtonUp()
    {
        PlayerRB.AddForce(-MoveDiection.GetComponent<Rigidbody>().velocity * MS, ForceMode.Acceleration);
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
        PlayerRB.AddForce(-MoveDiection.transform.right.normalized * MS, ForceMode.Acceleration);
    }
    public static void moveRight()
    {
        PlayerRB.AddForce(MoveDiection.transform.right.normalized * MS, ForceMode.Acceleration);
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
            DeathBoxPos = GameObject.FindGameObjectWithTag("DeathFloor").transform.position;
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
            GameObject.FindGameObjectWithTag("DeathFloor").transform.position = DeathBoxPos;
        }
    }
}
