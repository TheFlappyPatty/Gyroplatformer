using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayerMovement : MonoBehaviour
{
    public GameObject Camera;
    public float MoveSpeed;
    public float JumpHeight;
    public float MaxMoveSpeed;
    public float AntiSlide;
    public Rigidbody PlayerRB;
    private bool Inair;
    public float MouseSens;
    private bool IsMoving;

    public void Update()
    {
        if(PlayerRB.velocity.z > 1 || PlayerRB.velocity.x > 1)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
        if (PlayerRB.velocity.magnitude > MaxMoveSpeed)
        {
            PlayerRB.velocity = PlayerRB.velocity.normalized * MaxMoveSpeed;
        }
        if(Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.D) == false && Inair == false)
        {
            var AntislideForce = new Vector3(-PlayerRB.velocity.x, 0, -PlayerRB.velocity.z) * AntiSlide;
            PlayerRB.AddForce(AntislideForce, ForceMode.Acceleration); 
        }
        if (Input.GetKeyDown(KeyCode.Space) && Inair == false)
        {
            Inair = true;
            if(IsMoving == true)
            {
            PlayerRB.AddForce(transform.up * JumpHeight * 3, ForceMode.VelocityChange);
            }
            else
            {
            PlayerRB.AddForce(transform.up * JumpHeight, ForceMode.VelocityChange);
            }

        }

        PlayerRB.AddForce(transform.forward.normalized * Input.GetAxis("Vertical") * MoveSpeed,ForceMode.Acceleration);
        PlayerRB.AddForce(transform.right.normalized * Input.GetAxis("Horizontal") * MoveSpeed, ForceMode.Acceleration);
        Camera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * MouseSens, 0,0));
        transform.Rotate(0, Input.GetAxis("Mouse X") * MouseSens, 0);

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Inair = false;
        }
    }
}
