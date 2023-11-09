//using Palmmedia.ReportGenerator.Core;
using System.Collections;
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
    public bool IsMoving1;
    //audio
    public AudioClip[] footstepSounds;
    public float minTimeBetweenFootsteps = 0.3f;
    public float maxTimeBetweenFootsteps = 0.6f;

    private AudioSource audioSource;
    private float timeSinceLastFootstep;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        JH = JumpHeight;
        MS = MovementSpeed;
        DeathWall = GameObject.Find("Deathfloor");
        PlayerRB = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (gameObject.transform.position.y < DeathHieght)
        {
            Death();
        }
        MoveDiection = GameObject.Find("PlayerHead");
        if (IsMoving == false && IsMoving1 == false && Inair == false)
        {
            PlayerRB.AddForce(-PlayerRB.velocity * SlideResistance, ForceMode.Acceleration);
        }
        if (PlayerRB.velocity.magnitude > MaxSpeed)
        {
            PlayerRB.velocity = PlayerRB.velocity.normalized * MaxSpeed;
        }


        if (IsMoving || IsMoving1)
        {
            // Check if enough time has passed to play the next footstep sound
            if (Time.time - timeSinceLastFootstep >= Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps))
            {
                // Play a random footstep sound from the array
                AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
                audioSource.PlayOneShot(footstepSound);

                timeSinceLastFootstep = Time.time; // Update the time since the last footstep sound
            }
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
